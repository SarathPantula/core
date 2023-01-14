using core.Base.UnitOfWork;
using core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// 
/// </summary>
public static class BaseExtension
{
    /// <summary>
    /// Configure Base Extensions
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureBaseExtensions(this IServiceCollection services)
    {
        RegisterUnitOfWorkServices(services);

        return services;
    }

    private static void RegisterUnitOfWorkServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}