using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Infra.PostgreSQLDapper.Extensions;

public static class DapperExtensions
{
    public static IServiceCollection AddQueryRepositories(this IServiceCollection services)
    {
        return services;
    }
}