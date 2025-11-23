using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Breadboard.Infra.SwaggerUI.Extensions;

public static class SwaggerExtensions
{
    /// <summary>
    /// Remember to change launchSettings.json to search for Swagger at application start for easier testing
    /// Scalar is better, but anyway, I installed this package and there's
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services)
    {
        services.AddSwaggerGen()
                .AddVersionedApiExplorer(o =>
                {
                    o.GroupNameFormat = "'v'VVV";
                    o.SubstituteApiVersionInUrl = true;
                }
        );
        return services;
    }

    public static WebApplication AddSwaggerConfiguration(this WebApplication app)
    {
        if (app.Environment.IsDevelopment() || true)
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger()
               .UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant()
                    );
                }
                c.RoutePrefix = string.Empty;
                c.InjectStylesheet("/swagger-dark.css");
            });
        }

        return app;
    }
}