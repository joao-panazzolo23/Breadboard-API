using System.Net;
using Breadboard.Application.Exceptions;
using Breadboard.Application.Exceptions.Exceptions;
using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.ExceptionHandler.Strategies.Abstract;

namespace Breadboard.Presentation.ExceptionHandler.Strategies;

public class SystemExceptionStrategy : IExceptionStrategy
{
    public bool CanHandle(Exception exception) => exception is SystemException;

    public async Task<bool> Handle(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = new ExceptionResult(
            HttpStatusCode.InternalServerError,
            ((AppValidationException)exception).Errors,
            typeof(IExceptionStrategy).Assembly.GetName().Name);

        await context.Response.WriteAsJsonAsync(result, cancellationToken);

        return true;
    }
}