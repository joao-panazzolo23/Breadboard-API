using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.Documentation.Conventions.Abstract;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Breadboard.Presentation.Documentation.Conventions.Concrete;

public class ValidationConvention : IOpenApiConvention
{
    public Task ApplyAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken ct
    )
    {
        // var hasBody = context.Description.ParameterDescriptions
        //     .Any(p => p.Source == BindingSource.Body);

        // if (!hasBody) return Task.CompletedTask;

        var mediatype = new OpenApiMediaType()
        {
            Schema = new OpenApiSchemaReference(nameof(ExceptionResult), context.Document)
        };

        var content = new Dictionary<string, OpenApiMediaType>
        {
            ["application/problem+json"] = mediatype
        };

        var response = new OpenApiResponse
        {
            Description = "Bad Request — Validation failed",
            Content = content
        };

        
        operation.Responses.TryAdd(StatusCodes.Status400BadRequest.ToString(), response);

        return Task.CompletedTask;
    }
}