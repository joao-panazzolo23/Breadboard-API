using Breadboard.Application.Attributes;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Breadboard.Application.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddVersionedApiExplorer(o =>
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
                
                app.UseSwagger();
                app.UseSwaggerUI(c =>
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
}