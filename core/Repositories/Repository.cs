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

    /// <summary>
    /// GetAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity> GetAsync(Guid id)
    {
        return (await _context.Set<TEntity>().FindAsync(id))!;
    }

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    /// <summary>
    /// FindAsync
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    /// <summary>
    /// AddAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// AddRangeAsync
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    /// <summary>
    /// RemoveAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task RemoveAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// RemoveRangeAsync
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }
}

