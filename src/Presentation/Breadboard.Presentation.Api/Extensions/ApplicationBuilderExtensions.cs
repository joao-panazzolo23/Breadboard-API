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

    public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
    {
        ((WebApplication)app).Services.MigrateDataBase();
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