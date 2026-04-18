using Breadboard.Application.Pipelines;
using Breadboard.Application.Pipelines.Behaviors;
using FluentValidation;
using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        return services.AddValidatorsFromAssembly(typeof(ApplicationExtensions).Assembly)
            .AddPipelineBehaviors()
            .AddMediator(options => { options.ServiceLifetime = ServiceLifetime.Scoped; });
    }

    private static IServiceCollection AddPipelineBehaviors(
        this IServiceCollection services)
    {
        return services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
    
    
    
}