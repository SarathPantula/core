using core.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace core.Extensions.StartUpExtensions;

/// <summary>
/// ValidationBehavior Extension
/// </summary>
public static class ValidationBehaviorExtension
{
    /// <summary>
    /// Configure Validation Behavior Extensions
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureValidationBehaviorExtensions(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
