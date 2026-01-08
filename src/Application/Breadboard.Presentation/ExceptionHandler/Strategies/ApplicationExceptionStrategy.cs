using System.Net;
using Breadboard.Application.Exceptions;
using Breadboard.Application.Exceptions.Exceptions;
using Breadboard.Application.Exceptions.Models;

namespace Breadboard.Presentation.ExceptionHandler.Strategies;

public class ApplicationExceptionStrategy : IExceptionStrategy
{
    public bool CanHandle(Exception exception) => exception is AppValidationException;

    public async Task<bool> Handle(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var result = new ExceptionResult(
            HttpStatusCode.BadRequest,
            ((AppValidationException)exception).Errors,
            typeof(AppValidationException).Assembly.GetName().Name);

        await context.Response.WriteAsJsonAsync(result, cancellationToken);
        
        return true;
    }
}