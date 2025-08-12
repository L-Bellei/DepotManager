using AutoMapper;
using Depot.API.Common.Enums;
using Depot.API.Common.Interfaces.Repositories;
using Depot.API.Common.Notifier;
using Depot.API.Data;
using Depot.API.Features.Registrations.Interfaces;

namespace Depot.API.Features.Registrations.Services;

public class BaseRegistrationService<TRepo, TEntity, TRequest, TResponse>(TRepo repo, INotifier notifier, IMapper mapper, ILogger logger)
    : IBaseRegistrationService<TRequest, TResponse>
    where TRepo : IBaseRepository<DepotContext, TEntity> where TEntity : class
{
    protected readonly TRepo _repo = repo;
    protected readonly INotifier _notifier = notifier;
    protected readonly IMapper _mapper = mapper;
    protected readonly ILogger _logger = logger;

    public virtual async Task<IEnumerable<TResponse>?> GetAll(CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation($"Get all {nameof(TEntity)}");

            var list = await _repo.GetAllAsync(ct);

            _logger.LogInformation($"Total registers: {list.Count}");

            return _mapper.Map<IEnumerable<TResponse>>(list);
        }
        catch (Exception ex)
        {
            string message = $"Was not possible to get all {nameof(TEntity)} because {ex.Message}";

            _notifier.AddNotification(message, EFeature.Registrations);
            _logger.LogError(message);

            return default;
        }
    }

    public virtual async Task<TResponse?> Add(TRequest request, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation($"Adding a new register on {nameof(TEntity)}");

            var entity = _mapper.Map<TEntity>(request);

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);

            _logger.LogInformation($"Adding a new register on {nameof(TEntity)}");

            return _mapper.Map<TResponse>(entity);
        }
        catch (Exception ex)
        {
            string message = $"Was not possible to add {nameof(TEntity)} because {ex.Message}";

            _notifier.AddNotification(message, EFeature.Registrations);
            _logger.LogError(message);

            return default;
        }
    }

    public virtual async Task<bool> Delete(Guid id, CancellationToken ct = default)
    {
        try
        {
            var entity = await _repo.GetByIdAsync(ct, id);

            if (entity is null)
            {
                _notifier.AddNotification("Register not found.", EFeature.Registrations);
                _logger.LogError($"Was not possible to delete on {nameof(TEntity)}");

                return false;
            }

            _repo.Remove(entity);
            await _repo.SaveChangesAsync(ct);
            return true;
        }
        catch (Exception ex)
        {
            _notifier.AddNotification($"Was not possible to delete on {nameof(TEntity)} because {ex.Message}.", EFeature.Registrations);
            _logger.LogError($"Was not possible to delete on {nameof(TEntity)} because {ex.Message}");

            return false;
        }
    }
}
