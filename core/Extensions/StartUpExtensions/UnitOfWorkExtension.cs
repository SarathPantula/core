using core.Base.UnitOfWork;
using core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// Unit Of Work Extension
/// </summary>
public static class UnitOfWorkExtension
{
    /// <summary>
    /// Register Unit Of Work Services
    /// </summary>
    /// <param name="services">IServices Collection</param>
    /// <returns>Returns <see cref="IServiceCollection"/></returns>
    public static IServiceCollection RegisterUnitOfWorkServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
