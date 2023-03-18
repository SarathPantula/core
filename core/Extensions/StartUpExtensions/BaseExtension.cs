using core.Base;
using core.Models.AppSettings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// 
/// </summary>
public static class BaseExtension
{
    /// <summary>
    /// ConfigureBaseExtensions
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureBaseExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterIOptionsServices(services, configuration);
        RegisterNewtonsoftServices(services);
        RegisterSwaggerServices(services, configuration);
        RegisterValidationBehaviorServices(services);

        return services;
    }

    private static void RegisterNewtonsoftServices(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffk";
            options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });
    }

    private static void RegisterIOptionsServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringSettings>(options => configuration.GetSection("ConnectionStrings").Bind(options));
        services.Configure<AzureBlobSettings>(options => configuration.GetSection("AzureBlobStorage").Bind(options));
        services.Configure<SwaggerSettings>(options => configuration.GetSection("Swagger").Bind(options));
    }

    private static void RegisterSwaggerServices(IServiceCollection services, IConfiguration configuration)
    {
        SwaggerSettings swaggerSettings = configuration.GetSection("Swagger").Get<SwaggerSettings>()!;
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
    }

    private static void RegisterValidationBehaviorServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}