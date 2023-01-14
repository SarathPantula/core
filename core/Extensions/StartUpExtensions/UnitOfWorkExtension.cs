using core.Base.UnitOfWork;
using core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace core.Extensions.StartUpExtensions;

public static class UnitOfWorkExtension
{
    public static IServiceCollection ConfigureUnitOfWorkServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
