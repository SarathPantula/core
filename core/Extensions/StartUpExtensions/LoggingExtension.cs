using core.Models.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// Logging Configuration
/// </summary>
public static class LoggingExtension
{
    /// <summary>
    /// Register Serilog Logging
    /// </summary>
    /// <param name="services">Services Collection <see cref="IServiceCollection"/></param>
    /// <param name="configuration">COnfiguration <see cref="IConfiguration"/></param>
    /// <returns>Returns Services <see cref="IServiceCollection"/></returns>
    public static IServiceCollection RegisterSerilogLogging(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LoggingSettings>(options => configuration.GetSection("Logging").Bind(options));

        return services;
    }
}
