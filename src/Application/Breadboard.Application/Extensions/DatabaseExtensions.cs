using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;
using Breadboard.Shared.Options;

namespace Breadboard.Application.Extensions;

public static class DatabaseExtensions
{
    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        builder.ConfigureDbOptions();

        builder.Services.AddEntityFrameWork().AddQueryRepositories();

        return builder;
    }

    private static void ConfigureDbOptions(this WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<DatabaseOptions>()
                        .BindConfiguration("ConnectionStrings")
                        .ValidateDataAnnotations()
                        .ValidateOnStart();
    }

}
