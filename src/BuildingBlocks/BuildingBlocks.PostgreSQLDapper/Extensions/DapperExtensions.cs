using BuildingBlocks.PostgreSQLDapper.Context;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.PostgreSQLDapper.Extensions;

public static class DapperExtensions
{
    public static IServiceCollection AddQueryRepositories(this IServiceCollection services)
    {
        services.AddScoped<PostgreSqlContext>();
        
        foreach (var type in typeof(DapperExtensions).Assembly.GetQueryRepositories())
        {
            services.AddScoped(type.intefaceType, type.classType);
        }

        return services;
    }
}