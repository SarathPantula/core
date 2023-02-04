using core.Base.UnitOfWork;
using core.Models.AppSettings;
using core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.OpenApi.Models;
using System.Reflection;
using core.Base;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;

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
        RegisterUnitOfWorkServices(services);
        RegisterNewtonsoftServices(services);
        RegisterSwaggerServices(services, configuration);
        RegisterValidationBehaviorServices(services);
        RegisterRedisCacheServices(services);

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

    private static void RegisterUnitOfWorkServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }

    private static void RegisterIOptionsServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringsConfiguration>(options => configuration.GetSection("ConnectionStrings").Bind(options));
        services.Configure<SwaggerConfiguration>(options => configuration.GetSection("Swagger").Bind(options));
    }

    private static void RegisterSwaggerServices(IServiceCollection services, IConfiguration configuration)
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
    }

    private static void RegisterValidationBehaviorServices(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }

    private static void RegisterRedisCacheServices(IServiceCollection services)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost";
            options.InstanceName = "SampleInstance";
        });
        services.AddScoped<IDistributedCache, RedisCache>();
    }
}