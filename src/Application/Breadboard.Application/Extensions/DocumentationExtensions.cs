using Breadboard.Application.Transformers;

namespace Breadboard.Application.Extensions;

public static class DocumentationExtensions
{
    public static WebApplicationBuilder AddDocuments(this WebApplicationBuilder builder)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer<JwtSecuritySchemeTransformer>();
                //todo: finish this when authentication/authorization is done
                // options.AddDocumentTransformer<JwtInjectTestTransformer>();
            });
        }

        return builder;
    }
}