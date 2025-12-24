using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Shared.Options;

namespace Breadboard.Application.Extensions;

public static class DatabaseExtensions
{
    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        builder.ConfigureDbOptions();

        builder.Services.AddEntityFrameWork();

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
