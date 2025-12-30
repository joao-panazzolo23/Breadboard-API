using Breadboard.Presentation.Transformers;
using Microsoft.AspNetCore.OpenApi;

namespace Breadboard.Presentation.Extensions;

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