namespace core.Cache;

/// <summary>
/// ICacheService
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Get Data using key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    T GetData<T>(string key);

    /// <summary>
    /// SetData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    bool SetData<T>(string key, T value);

    /// <summary>
    /// Set Data with Value and Expiration Time of Key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expirationTime"></param>
    /// <returns></returns>
    bool SetData<T>(string key, T value, DateTimeOffset expirationTime);

    /// <summary>
    /// Remove Data
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    bool RemoveData(string key);
}