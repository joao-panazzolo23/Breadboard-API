using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Scalar.AspNetCore;

namespace Breadboard.Infra.Scalar.Extensions;

public static class ScalarExtensions
{
    public static WebApplication AddScalarInterface(this WebApplication app, WebApplicationBuilder builder)
    {
        if (!app.Environment.IsDevelopment()) return app;

        app.MapOpenApi("/openapi/{documentName}.json");

        app.MapScalarApiReference(options =>
        {
            options.WithTitle("Breadboard API V1")
                .WithClassicLayout()
                .HideSearch()
                .ShowOperationId()
                .SortTagsAlphabetically()
                .SortOperationsByMethod()
                .PreserveSchemaPropertyOrder()
                ;
        });

        return app;
    }
}