using Breadboard.Presentation.ExceptionHandler.Strategies.Abstract;
using Microsoft.AspNetCore.Diagnostics;

namespace Breadboard.Presentation.ExceptionHandler;

public sealed class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> logger,
    IEnumerable<IExceptionStrategy> handlers
) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        logger.LogError($"Exception registered: {exception.Message}", exception);

        foreach (var handler in handlers)
        {
            if (await handler.Handle(httpContext, exception, cancellationToken))
                return true;
        }

        return false;
    }
}