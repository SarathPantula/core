using System.Linq.Expressions;

namespace core.Repositories;

/// <summary>
/// IRepository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// GetAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TEntity> GetAsync(Guid id);

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>
    /// FindAsync
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// AddRangeAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity> AddAsync(TEntity entity);

    /// <summary>
    /// AddRangeAsync
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// RemoveAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task RemoveAsync(TEntity entity);

    /// <summary>
    /// RemoveRangeAsync
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);
}