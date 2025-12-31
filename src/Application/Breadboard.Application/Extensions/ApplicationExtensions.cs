using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(ApplicationExtensions).Assembly;

        return services.AddValidatorsFromAssembly(assembly)
                       .AddCops(assembly);
    }
}