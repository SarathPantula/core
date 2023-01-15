using Newtonsoft.Json;
using StackExchange.Redis;

namespace core.Cache;

/// <summary>
/// Cache Service
/// </summary>
public class CacheService : ICacheService
{
    private readonly IDatabase _db;
    /// <summary>
    /// ctor
    /// </summary>
    public CacheService()
    {
        _db = RedisConnectionHelper.Connection.GetDatabase();
    }

    /// <summary>
    /// GetData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    public T GetData<T>(string key)
    {
        var value = _db.StringGet(key);
        if (!string.IsNullOrEmpty(value))
        {
            return JsonConvert.DeserializeObject<T>(value!)!;
        }
        return default!;
    }

    /// <summary>
    /// SetData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool SetData<T>(string key, T value)
    {
        var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value));
        return isSet;
    }

    /// <summary>
    /// SetData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="expirationTime"></param>
    /// <returns></returns>
    public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
        var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
        return isSet;
    }

    /// <summary>
    /// RemoveData
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool RemoveData(string key)
    {
        bool _isKeyExist = _db.KeyExists(key);
        if (_isKeyExist)
        {
            return _db.KeyDelete(key);
        }
        return false;
    }
}