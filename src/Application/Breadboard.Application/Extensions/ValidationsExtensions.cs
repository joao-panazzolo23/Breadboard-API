using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Application.Extensions;

internal static class ValidationsExtensions
{
    public static IServiceCollection AddValidations(this IServiceCollection services, Assembly assembly)
    {
        return services.AddValidatorsFromAssembly(assembly);
    }
}