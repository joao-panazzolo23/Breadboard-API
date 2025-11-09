using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Breadboard.Infra.PostgreSQL.Extensions;

public static class EntityExtensions
{
    public static IServiceCollection AddEntityFrameWork(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddRepositories();
        //services.AddNpgsql<AppDbContext>(configuration["DefaultConnection"]);
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        //inject repositores dependencies here
        // services.AddScoped();

        return services;
    }

    public static IServiceProvider EnsureDbCreation(this IServiceProvider serviceProvider)
    {
        serviceProvider.CreateScope()
            .ServiceProvider
            .GetRequiredService<AppDbContext>()
            .Database
            .Migrate();

        return serviceProvider;
    }
}