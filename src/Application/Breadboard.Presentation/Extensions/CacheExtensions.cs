namespace Breadboard.Presentation.Extensions;

public static class CacheExtensions
{
    public static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache()
                       .AddDistributedMemoryCache();
        return builder;
    }
}