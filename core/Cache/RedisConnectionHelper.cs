using core.Base;
using StackExchange.Redis;

namespace core.Cache;

/// <summary>
/// Redis Connection Helper
/// </summary>
public class RedisConnectionHelper
{
    /// <summary>
    /// ctor
    /// </summary>
    static RedisConnectionHelper()
    {
        RedisConnectionHelper.LazyConnection = new Lazy<ConnectionMultiplexer>(()
            => ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]!));
    }
    private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

    /// <summary>
    /// Redis Connection
    /// </summary>
    public static ConnectionMultiplexer Connection => LazyConnection.Value;
}