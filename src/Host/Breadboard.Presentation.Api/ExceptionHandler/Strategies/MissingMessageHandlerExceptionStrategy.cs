using System.Net;
using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.ExceptionHandler.Strategies.Abstract;
using Mediator;

namespace Breadboard.Presentation.ExceptionHandler.Strategies;

public class MissingMessageHandlerExceptionStrategy : IExceptionStrategy
{

    public async Task<bool> Handle(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        if (exception is not MissingMessageHandlerException) return false;


        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = new ExceptionResult(
            HttpStatusCode.InternalServerError,
            [],
            typeof(MissingMessageHandlerException).Assembly.GetName().Name);

        await context.Response.WriteAsJsonAsync(result, cancellationToken);

        return true;
    }
}