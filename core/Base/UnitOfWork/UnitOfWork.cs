using core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace core.Base.UnitOfWork;

/// <summary>
/// UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private Dictionary<Type, object> _repositories;

    /// <summary>
    /// UnitOfWork
    /// </summary>
    /// <param name="context"></param>
    public UnitOfWork(DbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    /// <summary>
    /// GetRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new Repository<TEntity>(_context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
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