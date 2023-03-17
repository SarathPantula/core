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
        RedisConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]!);
        });
    }
    private static readonly Lazy<ConnectionMultiplexer> lazyConnection;

    /// <summary>
    /// Redis Connection
    /// </summary>
    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }
}