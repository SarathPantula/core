using core.Models.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// Swagger Extension
/// </summary>
public static class SwaggerExtension
{
    /// <summary>
    /// Configure Swagger
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        SwaggerConfiguration swaggerSettings = configuration.GetSection("Swagger").Get<SwaggerConfiguration>()!;
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(swaggerSettings.Version, new OpenApiInfo
            {
                Title = swaggerSettings.Title,
                Version = swaggerSettings.Version,
                Description = swaggerSettings.Description,
                TermsOfService = new Uri(swaggerSettings.TermsOfService),
                Contact = new OpenApiContact
                {
                    Name = swaggerSettings.Contact.Name,
                    Email = swaggerSettings.Contact.Email,
                    Url = new Uri(swaggerSettings.Contact.Url),
                },
                License = new OpenApiLicense
                {
                    Name = swaggerSettings.License.Name,
                    Url = new Uri(swaggerSettings.License.Url)
                }
            });

            var xmlFile = $"{Assembly.GetEntryAssembly()!.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}