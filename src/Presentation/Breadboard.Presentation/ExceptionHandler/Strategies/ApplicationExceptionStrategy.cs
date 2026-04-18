using System.Net;
using Breadboard.Application.Exceptions.Exceptions;
using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.ExceptionHandler.Strategies.Abstract;

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

        if (exception is not AppValidationException validationException) return false;

        var response = new ExceptionResult(
            System.Net.HttpStatusCode.BadRequest,
            validationException.Errors,
            "Application"
        );

        await context.Response.WriteAsJsonAsync(response, cancellationToken);


        return true;
    }
}