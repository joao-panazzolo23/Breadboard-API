using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace Breadboard.Presentation.Transformers;

/// <summary>
/// In this particular case, We're adding Bearer scheme for requests with Authorization schema.
/// 
/// It will not affect public endpoints, but will require bearer tokens for locked endpoints.
/// </summary>
/// <param name="document"></param>
/// <param name="context"></param>
/// <param name="cancellationToken"></param>
/// <returns></returns>
 public class JwtSecuritySchemeTransformer : IOpenApiDocumentTransformer
 {
     public Task TransformAsync(OpenApiDocument document, 
         OpenApiDocumentTransformerContext context,
         CancellationToken cancellationToken)
     {
         document.Components ??= new OpenApiComponents();

         document.Components.SecuritySchemes["bearerAuth"] = new OpenApiSecurityScheme
         {
             Type = SecuritySchemeType.Http,
             Scheme = "bearer",
             BearerFormat = "JWT",
             In = ParameterLocation.Header,
             Name = "Authorization"
         };

         document.SecurityRequirements.Add(
             new OpenApiSecurityRequirement
             {
                 {
                     new OpenApiSecurityScheme
                     {
                         Reference = new OpenApiReference
                         {
                             Type = ReferenceType.SecurityScheme,
                             Id = "bearerAuth"
                         }
                     },
                     Array.Empty<string>()
                 }
             }
         );

         return Task.CompletedTask;
     }
     
}
