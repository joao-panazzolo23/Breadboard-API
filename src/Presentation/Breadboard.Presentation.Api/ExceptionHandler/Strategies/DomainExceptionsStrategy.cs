using System.Net;
using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.ExceptionHandler.Strategies.Abstract;
using Breadboard.Shared.Exceptions;

namespace Breadboard.Presentation.ExceptionHandler.Strategies;

public class DomainExceptionsStrategy : IExceptionStrategy
{
    public bool CanHandle(Exception exception) => exception is DomainException;

    public async Task<bool> Handle(HttpContext context, Exception exception, CancellationToken cancellationToken)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var result = new ExceptionResult(
            HttpStatusCode.BadRequest, null, 
            typeof(DomainException).Assembly.GetName().Name,
            exception.Message);

        await context.Response.WriteAsJsonAsync(result, cancellationToken);
        
        return true;
    }
}