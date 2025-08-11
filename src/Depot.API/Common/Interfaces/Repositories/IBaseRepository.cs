using System.Linq.Expressions;

namespace Depot.API.Common.Interfaces.Repositories;

public interface IBaseRepository<TContext, TEntity>
{
    Task<TEntity?> GetByIdAsync(CancellationToken ct = default, params object[] keyValues);
    Task<List<TEntity>> GetAllAsync(CancellationToken ct = default);
    Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
    Task AddAsync(TEntity entity, CancellationToken ct = default);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
