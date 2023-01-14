using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// Core Extension
/// </summary>
public static class CoreExtension
{
    /// <summary>
    /// Configure Core Extensions
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureCoreExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureIOptions(configuration);
        services.ConfigureBaseExtensions();
        services.ConfigureNewtonsoftJson();
        services.ConfigureSwagger(configuration);
        services.ConfigureUnitOfWorkServices();

        return services;
    }
}
