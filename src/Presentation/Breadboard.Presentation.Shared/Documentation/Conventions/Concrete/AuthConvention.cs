using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.Documentation.Conventions.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Breadboard.Presentation.Documentation.Conventions.Concrete;

public class AuthConvention : IOpenApiConvention
{
    public async Task ApplyAsync(
        OpenApiOperation operation,
        OpenApiOperationTransformerContext context,
        CancellationToken ct)
    {
        var schema = await context.GetOrCreateSchemaAsync(typeof(ExceptionResult), null, ct);
        context.Document?.AddComponent(nameof(ExceptionResult), schema);

        var metadata = context.Description.ActionDescriptor.EndpointMetadata;

        var hasAuthorize = metadata
            .OfType<IAuthorizeData>()
            .Any();

        var allowsAnonymous = metadata
            .OfType<IAllowAnonymous>()
            .Any();

        if (!hasAuthorize || allowsAnonymous) return;

        operation.Responses.TryAdd(StatusCodes.Status401Unauthorized.ToString(), new OpenApiResponse { Description = "Unauthorized" });
        operation.Responses.TryAdd(StatusCodes.Status403Forbidden.ToString(), new OpenApiResponse { Description = "Forbidden" });
    }
}


