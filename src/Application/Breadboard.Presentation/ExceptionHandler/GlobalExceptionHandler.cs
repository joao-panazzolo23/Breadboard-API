using Breadboard.Presentation.ExceptionHandler.Strategies;
using Microsoft.AspNetCore.Diagnostics;

namespace Breadboard.Presentation.ExceptionHandler;

public class GlobalExceptionHandler(
    ILogger<GlobalExceptionHandler> _logger,
    IEnumerable<IExceptionStrategy> _strategies
) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        _logger.LogError($"Exception registered : {exception.Message}");

        var handler = _strategies.FirstOrDefault(x => x.CanHandle(exception));

        if (handler is null) return false;

        return await handler.Handle(httpContext, exception, cancellationToken);
    }
}