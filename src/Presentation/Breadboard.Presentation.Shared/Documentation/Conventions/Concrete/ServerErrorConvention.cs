using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.Documentation.Conventions.Abstract;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Breadboard.Presentation.Documentation.Conventions.Concrete;

public class ServerErrorConvention : IOpenApiConvention
{
    public Task ApplyAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context, CancellationToken ct)
    {
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
            Description = "Internal Server Error",
            Content = content
        };

        operation.Responses.TryAdd(StatusCodes.Status500InternalServerError.ToString(), response);

        return Task.CompletedTask;
    }
}