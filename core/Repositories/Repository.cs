using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace core.Repositories;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public Repository(DbContext context)
    {
        _context = context;
    }
    
    /// <inheritdoc />
    public async Task<TEntity> GetAsync(Guid id)
    {
        return (await _context.Set<TEntity>().FindAsync(id))!;
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> AddRangeAsync(IList<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    /// <inheritdoc />
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    /// <inheritdoc />
    public async Task RemoveByIdAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity != null)
            _context.Set<TEntity>().Remove(entity);
    }

    /// <inheritdoc />
    public async Task RemoveAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}

