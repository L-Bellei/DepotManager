namespace Depot.API.Features.Registrations.Interfaces;

public interface IBaseRegistrationService<TRequest, TResponse>
{
    Task<IEnumerable<TResponse>?> GetAll(CancellationToken ct = default);
    Task<TResponse?> Add(TRequest request, CancellationToken ct = default);
    Task<bool> Delete(Guid id, CancellationToken ct = default);
}
