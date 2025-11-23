using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Scalar.AspNetCore;

namespace Breadboard.Infra.Scalar.Extensions;

public static class ScalarExtensions
{
    public static WebApplication AddScalarInterface(this WebApplication app, WebApplicationBuilder builder)
    {
        if (app.Environment.IsDevelopment())
        {
            //todo: discover how to set API Version dynamically
            // var version = Assembly.GetExecutingAssembly().GetName().Version!;
            // builder.Services.AddOpenApi(options =>
            // {
            //     options.DocumentName = $"v{version.Major}.{version.Minor}";
            // });

            app.MapOpenApi("/openapi/{documentName}.json");

            app.MapScalarApiReference(options =>
            {
                options.WithTitle("Breadboard API V1")
                    .WithClassicLayout()
                    .ForceDarkMode()
                    .HideSearch()
                    .ShowOperationId()
                    .ExpandAllTags()
                    .SortTagsAlphabetically()
                    .SortOperationsByMethod()
                    .PreserveSchemaPropertyOrder()
                    //.WithOpenApiRoutePattern("/openapi/{documentName}.json")
                    ;

                // .WithProxy("https://api-gateway.company.com")
                // .AddServer("https://api.company.com", "Production")
                // .AddServer("https://staging-api.company.com", "Staging");
            });
        }

        return app;
    }
}