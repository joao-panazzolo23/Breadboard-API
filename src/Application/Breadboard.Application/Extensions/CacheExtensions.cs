namespace Breadboard.Application.Extensions;

public static class CacheExtensions
{
    public static IServiceCollection AddCaching(this IServiceCollection services)
    {
        services.AddMemoryCache()
            .AddDistributedMemoryCache();

        return services;
    }
}