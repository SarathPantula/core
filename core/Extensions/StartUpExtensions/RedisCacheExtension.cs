using core.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// Redis Cache Extension
/// </summary>
public static class RedisCacheExtension
{
    /// <summary>
    /// Register Redis Cache Services
    /// </summary>
    /// <param name="services">IServices Collection</param>
    /// <returns>Returns <see cref="IServiceCollection"/></returns>
    public static IServiceCollection RegisterRedisCacheServices(IServiceCollection services)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "redis:6379,abortConnect=false";
            options.InstanceName = "SampleInstance";
        });
        services.AddScoped<IDistributedCache, RedisCache>();
        services.AddScoped<ICacheService, CacheService>();

        return services;
    }
}
