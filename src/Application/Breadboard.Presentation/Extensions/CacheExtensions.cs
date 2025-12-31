namespace Breadboard.Presentation.Extensions;

public static class CacheExtensions
{
    public static IServiceCollection AddCaching(this IServiceCollection services)
    {
        return services.AddMemoryCache()
                       .AddDistributedMemoryCache();
    }
}