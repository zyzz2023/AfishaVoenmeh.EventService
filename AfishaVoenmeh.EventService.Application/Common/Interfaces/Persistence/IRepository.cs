using AfishaVoenmeh.EventService.Domain.Common.Interfaces;
using System.Linq.Expressions;

namespace AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;

public interface IRepository<TEntity> 
    where TEntity : class, IEntity<Guid>
{
    Task<TEntity?> GetByIdAsync(Guid id, bool enableTracking, CancellationToken ct = default);
    Task<IEnumerable<TEntity?>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(TEntity entity, CancellationToken ct = default);

    Task UpdateAsync(TEntity entity, CancellationToken ct = default);
    Task DeleteAsync(TEntity entity, CancellationToken ct = default);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
