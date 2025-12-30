using Scalar.AspNetCore;

namespace Breadboard.Presentation.Extensions;

public static class ScalarExtensions
{
    public static WebApplication AddScalarInterface(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment()) return app;
        
        app.MapOpenApi();

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