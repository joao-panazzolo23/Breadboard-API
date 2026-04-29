using Breadboard.Presentation.Documentation.Conventions.Concrete;
using Breadboard.Presentation.Pipelines;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;


namespace Breadboard.Presentation.Transformers;

public class ConventionOperationTransformer : IOpenApiOperationTransformer
{
    public async Task TransformAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken ct)
    {
        var pipeline = new OpenApiConventionExecuter([
            new AuthConvention(),
            new ValidationConvention(),
            new ServerErrorConvention(),
            new DeprecationConvention()
        ]);

     await pipeline.Run(operation, context, ct);
    }
}
