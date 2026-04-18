using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Breadboard.Presentation.Documentation.Conventions.Abstract;

public interface IOpenApiConvention
{
    Task ApplyAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken ct);
}