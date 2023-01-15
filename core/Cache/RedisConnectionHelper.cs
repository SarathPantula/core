using core.Base;
using StackExchange.Redis;

namespace core.Cache;

public class RedisConnectionHelper
{
    static RedisConnectionHelper()
    {
        RedisConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]!);
        });
    }
    private static Lazy<ConnectionMultiplexer> lazyConnection;
    public static ConnectionMultiplexer Connection
    {
        get
        {
            return lazyConnection.Value;
        }
    }
}