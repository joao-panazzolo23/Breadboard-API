using Breadboard.Application.Behaviors;
using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        var assembly = typeof(ApplicationExtensions).Assembly;
        
        return services.AddValidatorsFromAssembly(assembly)
            .AddPipelineBehaviors()
            .AddMediator(options =>
            {
                options.ServiceLifetime = ServiceLifetime.Scoped;
            });
       
    }

    private static IServiceCollection AddPipelineBehaviors(
        this IServiceCollection services)
    {
        return services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
