using Breadboard.Presentation.Documentation.Conventions.Abstract;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Breadboard.Presentation.Documentation.Conventions.Concrete;

public class DeprecationConvention : IOpenApiConvention
{
    public Task ApplyAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken ct
    )
    {
        var metadata = context.Description.ActionDescriptor.EndpointMetadata;

        var isDeprecated = metadata
            .OfType<ObsoleteAttribute>()
            .Any();

        if (!isDeprecated) return Task.CompletedTask;

        operation.Deprecated = true;

        return Task.CompletedTask;
    }
}