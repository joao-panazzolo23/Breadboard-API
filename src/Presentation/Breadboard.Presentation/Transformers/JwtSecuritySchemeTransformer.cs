using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Breadboard.Presentation.Transformers;

public class JwtSecuritySchemeTransformer : IOpenApiDocumentTransformer
{
    /// <summary>
    /// In this particular case, We're adding Bearer scheme for requests with Authorization schema.
    /// 
    /// It will not affect public endpoints, but will require bearer tokens for locked endpoints.
    /// </summary>
    /// <param name="document"></param>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task TransformAsync(
        OpenApiDocument document,
        OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken
    )
    {
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();

        var bearerScheme = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization"
        };

        document.Components.SecuritySchemes["bearerAuth"] = bearerScheme;

        document.Security ??= [];
        document.Security.Clear();

        var requirements = new OpenApiSecurityRequirement
        {
            { new OpenApiSecuritySchemeReference("bearerAuth"), [] }
        };

        document.Security.Add(requirements);

        return Task.CompletedTask;
    }
}