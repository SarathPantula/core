using core.Models.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// IOptionsExtension
/// </summary>
public static class IOptionsExtension
{
    /// <summary>
    /// Configure IOptions
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureIOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringsConfiguration>(options => configuration.GetSection("ConnectionStrings").Bind(options));
        services.Configure<SwaggerConfiguration>(options => configuration.GetSection("Swagger").Bind(options));

        return services;
    }
}