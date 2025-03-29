using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace core.Cache;

/// <summary>
/// Cache Service
/// </summary>
public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    /// <summary>
    /// ctor
    /// </summary>
    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    /// GetOrCreateAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="factory"></param>
    /// <returns></returns>
    public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory) where T : class
    {
        var cachedData = await _cache.GetStringAsync(key);
        if (!string.IsNullOrEmpty(cachedData))
        {
            return JsonConvert.DeserializeObject<T>(cachedData)!;
        }

        var data = await factory();
        await CreateAsync(key, data);

        return data;
    }

    /// <summary>
    /// GetOrCreateAsync
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="data"></param>
    /// <param name="expiresIn"></param>
    /// <returns></returns>
    public async Task CreateAsync<T>(string key, T data, TimeSpan? expiresIn = null) where T : class
    {
        expiresIn ??= TimeSpan.FromDays(1);

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.Add(expiresIn.Value)
        };
        await _cache.SetStringAsync(key, JsonConvert.SerializeObject(data), options);
    }
}