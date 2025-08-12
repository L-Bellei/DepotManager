using Depot.API.Common.Enums;
using Depot.API.Common.Notifier;
using Depot.API.Common.Views;
using Microsoft.AspNetCore.Mvc;

namespace Depot.API.Common.Endpoints;

[ApiController]
public abstract class BaseEndpoint(INotifier notifier) : ControllerBase
{
    private readonly INotifier _notifier = notifier;

    /// <summary>
    /// Retorna sucesso (com status customizável) ou erro consolidado.
    /// </summary>
    protected IActionResult CustomResponse<T>(
        T? data = default,
        int successStatusCode = StatusCodes.Status200OK,
        int failStatusCode = StatusCodes.Status400BadRequest)
    {
        if (_notifier.HasNotifies())
            return StatusCode(failStatusCode, Fail(_notifier.GetNotifications()));

        if (successStatusCode == StatusCodes.Status204NoContent)
            return NoContent();

        return StatusCode(successStatusCode, Success(data!));
    }

    /// <summary>
    /// Converte ModelState inválido em notificações e retorna 400.
    /// </summary>
    protected IActionResult CustomResponseFromModelState(
        int failStatusCode = StatusCodes.Status400BadRequest)
    {
        if (ModelState.IsValid)
            return CustomResponse<object?>(null);

        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            _notifier.AddNotification(error.ErrorMessage, EFeature.Endpoints);

        return CustomResponse<object?>(null, failStatusCode: failStatusCode);
    }

    /// <summary>
    /// Retorna 201 Created com Location via rota nomeada.
    /// </summary>
    protected IActionResult CreatedResponse<T>(string routeName, object routeValues, T data)
    {
        if (_notifier.HasNotifies())
            return StatusCode(StatusCodes.Status400BadRequest, Fail(_notifier.GetNotifications()));

        return CreatedAtRoute(routeName, routeValues, Success(data!));
    }

    private static SuccessResponseView Success(object data) => new(data);
    private static ErrorResponseView Fail(IReadOnlyList<string> errors) => new(errors);
}
