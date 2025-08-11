using Depot.API.Common.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Depot.API.Common.Repositories;

public abstract class BaseRepository<TContext, TEntity> where TContext : DbContext where TEntity : class, IBaseRepository<TContext, TEntity>
{
    protected readonly TContext _context;
    protected readonly DbSet<TEntity> _set;

    protected BaseRepository(TContext context)
    {
        _context = context;
        _set = _context.Set<TEntity>();
    }

    protected virtual IQueryable<TEntity> Query(bool asNoTracking = true)
        => asNoTracking ? _set.AsNoTracking() : _set;

    public virtual async Task<TEntity?> GetByIdAsync(CancellationToken ct = default, params object[] keyValues)
        => await _set.FindAsync(keyValues, ct);

    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken ct = default)
        => await Query().ToListAsync(ct);

    public virtual async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        => await Query().Where(predicate).ToListAsync(ct);

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        => await Query().AnyAsync(predicate, ct);

    public virtual async Task AddAsync(TEntity entity, CancellationToken ct = default) 
        => await _set.AddAsync(entity, ct);

    public virtual void AddRange(IEnumerable<TEntity> entities)
        => _set.AddRange(entities);

    public virtual void Update(TEntity entity)
        => _set.Update(entity);

    public virtual void Remove(TEntity entity)
        => _set.Remove(entity);

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
        => _set.RemoveRange(entities);

    public virtual async Task<int> SaveChangesAsync(CancellationToken ct = default)
        => await _context.SaveChangesAsync(ct);
}
