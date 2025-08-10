using Depot.API.Common.Enums;
using Depot.API.Common.Interfaces;
using Depot.API.Common.Views;
using Microsoft.AspNetCore.Mvc;

namespace Depot.API.Common.Endpoints;

[ApiController]
public abstract class BaseEndpoint(INotifier notifier) : ControllerBase
{
    private readonly INotifier _notifier = notifier;

    /// <summary>
    /// Retorna sucesso (com status customizável) ou erro consolidado das notificações.
    /// </summary>
    public IActionResult CustomResponse<T>(T? data = default,
        int successStatusCode = StatusCodes.Status200OK,
        int failStatusCode = StatusCodes.Status400BadRequest)
    {
        if (_notifier.HasNotifies())
            return StatusCode(failStatusCode, Fail(_notifier.GetNotifications()));

        if (data is null && successStatusCode == StatusCodes.Status204NoContent)
            return StatusCode(StatusCodes.Status204NoContent);

        return StatusCode(successStatusCode, Success(data!));
    }

    /// <summary>
    /// Converte erros do ModelState em notificações e responde usando CustomResponse.
    /// </summary>
    protected IActionResult CustomResponseFromModelState(int failStatusCode = StatusCodes.Status400BadRequest)
    {
        if (ModelState.IsValid)
            return CustomResponse<object?>(null);

        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            _notifier.AddNotification(error.ErrorMessage, EFeature.Endpoints);

        return CustomResponse<object?>(null, failStatusCode: failStatusCode);
    }

    /// <summary>
    /// Helper para 201 Created com location.
    /// </summary>
    protected IActionResult CreatedResponse<T>(string routeName, object routeValues, T data)
    {
        if (_notifier.HasNotifies())
            return CustomResponse<T>(data);

        var body = Success(data!);
        return CreatedAtRoute(routeName, routeValues, body);
    }

    private static SuccessResponseView Success(object data) => new(data);

    private static ErrorResponseView Fail(IReadOnlyList<string> errors) => new(errors);
}
