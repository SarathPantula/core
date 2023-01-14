using core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace core.Base.UnitOfWork;

/// <summary>
/// UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    /// <summary>
    /// UnitOfWork
    /// </summary>
    /// <param name="context"></param>
    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GetRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        return new Repository<TEntity>(_context);
    }

    /// <summary>
    /// SaveChangesAsync
    /// </summary>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }
}