using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;
using Breadboard.Shared.Options;

namespace Breadboard.Presentation.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.ConfigureDbOptions()
                       .AddEntityFrameWork()
                       .AddQueryRepositories();


    }

    private static IServiceCollection ConfigureDbOptions(this IServiceCollection services)
    {
        services.AddOptions<DatabaseOptions>()
                .BindConfiguration("ConnectionStrings")
                .ValidateDataAnnotations()
                .ValidateOnStart();

        return services;
    }

}
