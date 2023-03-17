using Microsoft.Extensions.Configuration;

namespace core.Base;

/// <summary>
/// Configuration Manager
/// </summary>
public static class ConfigurationManager
{
    /// <summary>
    /// AppSetting
    /// </summary>
    public static IConfiguration AppSetting
    {
        get;
    }
    static ConfigurationManager()
    {
        AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
    }
}
