using Breadboard.Presentation.Documentation.Conventions.Abstract;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Breadboard.Presentation.Pipelines;

public class OpenApiConventionExecuter(IEnumerable<IOpenApiConvention> conventions)
{
    public async Task Run(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken ct)
    {
        foreach (var convention in conventions)
            await convention.ApplyAsync(operation, context, ct);
    }
}