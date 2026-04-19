using Breadboard.Application;
using Breadboard.Application.Users.Repositories;
using Breadboard.Infra.PostgreSQL.Repositories;
using Breadboard.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Breadboard.Infra.PostgreSQL.Extensions;

public static class EntityExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddEntityFrameWork()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                var dbSettings = sp
                    .GetRequiredService<IOptions<DatabaseOptions>>()
                    .Value;

                options.UseNpgsql(dbSettings.DefaultConnection);
            });

            return services.AddRepositories();
        }
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IUnityOfWork, UnityOfWork>()
            .AddScoped<IUserRepository, UserRepository>();
    }

    /// <summary>
    /// todo: we're doing two things inside this function: getting Database Context & updating db
    /// maybe this isn't the best approach for this function, but creating another one is also useless
    /// it won't be used anywhere else 
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public static IServiceProvider MigrateDataBase(this IServiceProvider serviceProvider)
    {
        serviceProvider.CreateScope()
            .ServiceProvider
            .GetRequiredService<AppDbContext>()
            .Database
            .Migrate();

        return serviceProvider;
    }
}