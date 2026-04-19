using Breadboard.Presentation.Transformers;
using Scalar.AspNetCore;

namespace Breadboard.Presentation.Extensions;

public static class DocumentationExtensions
{
    public static IServiceCollection AddDocuments(
        this IServiceCollection services,
        IHostEnvironment environment
    )
    {
        if (environment.IsDevelopment())
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer<JwtSecuritySchemeTransformer>();
                options.AddOperationTransformer<ConventionOperationTransformer>();
                //todo: finish this when authentication/authorization is done
                // options.AddDocumentTransformer<JwtInjectTestTransformer>();
            });
        }

        return services;
    }

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
                .WithTheme(theme: ScalarTheme.DeepSpace)
                ;
        });

        return app;
    }
}