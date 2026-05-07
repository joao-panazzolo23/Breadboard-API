using BuildingBlocks.PostgreSQL.Extensions;

namespace Breadboard.Presentation.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
    {
        return app
            .UseAuthentication()
            .UseAuthorization();
    }

    public static async Task<IApplicationBuilder> MigrateDatabase(this IApplicationBuilder app)
    {
        await ((WebApplication)app).Services.MigrateDataBaseAsync();
        return app;
    }

    public static IApplicationBuilder UseDocumentation(this IApplicationBuilder app)
    {
        return ((WebApplication)app).AddScalarInterface();
    }

    public static IApplicationBuilder UseControllers(this IApplicationBuilder app)
    {
        ((IEndpointRouteBuilder)app).MapControllers();
        return app;
    }
}