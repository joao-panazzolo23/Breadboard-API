using Breadboard.Presentation.Transformers;

namespace Breadboard.Presentation.Extensions;

public static class DocumentationExtensions
{
    public static IServiceCollection AddDocuments(this IServiceCollection services, IHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer<JwtSecuritySchemeTransformer>();
                //todo: finish this when authentication/authorization is done
                // options.AddDocumentTransformer<JwtInjectTestTransformer>();
            });
        }

        return services;
    }
}