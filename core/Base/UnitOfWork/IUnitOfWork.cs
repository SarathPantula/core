using core.Repositories;

namespace core.Base.UnitOfWork;

/// <summary>
/// IUnitOfWork
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// GetRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    /// <summary>
    /// SaveChangesAsync
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
}