using System.Reflection;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Infra.PostgreSQLDapper.Extensions;

public static class DapperExtensions
{
    public static IServiceCollection AddQueryRepositories(this IServiceCollection services, Assembly assembly)
    {
        foreach (var type in assembly.GetQueryRepositories())
        {
            services.AddScoped(type.intefaceType, type.classType);
        }
           
        return services;
    }
}