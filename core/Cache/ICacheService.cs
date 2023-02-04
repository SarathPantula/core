namespace core.Cache;

/// <summary>
/// ICacheService
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// GetOrCreateAsync
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<T> GetAsync<T>(string key) where T : class;

    /// <summary>
    /// GetOrCreateAsync
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="expiresIn"></param>
    /// <returns></returns>
    Task CreateAsync<T>(string key, T data, TimeSpan? expiresIn = null) where T : class;
}