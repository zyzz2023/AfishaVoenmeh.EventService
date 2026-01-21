using AfishaVoenmeh.EventService.Application.Common.Interfaces.Persistence;
using AfishaVoenmeh.EventService.Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AfishaVoenmeh.EventService.Infrastructure.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity<Guid>
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, bool enableTracking, CancellationToken ct = default)
    {
        var query = _context.Set<TEntity>()
            .AsQueryable();

        if (!enableTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(entity => entity.Id == id, ct);
    }

    public async Task<IEnumerable<TEntity?>> GetAllAsync(CancellationToken ct = default)
    {
        return await _context.Set<TEntity>().ToListAsync(ct);
    }

    public async Task AddAsync(TEntity entity, CancellationToken ct = default)
    {
        await _context.AddAsync(entity, ct);

        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken ct = default)
    {
        _context.Update(entity);

        await _context.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken ct = default)
    {
        _context.Remove(entity);

        await _context.SaveChangesAsync(ct);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
    {
        return await _context
            .Set<TEntity>()
            .AnyAsync(predicate, ct);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
    {
        return await _context
            .Set<TEntity>()
            .CountAsync(predicate, ct);
    }
}