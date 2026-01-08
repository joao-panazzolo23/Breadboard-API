using Breadboard.Application.Exceptions;
using Breadboard.Application.Exceptions.Exceptions;
using Breadboard.Application.ResultPattern;
using FluentValidation;
using Mediator;

namespace Breadboard.Application.Pipelines;

public sealed class ValidationBehavior<TMessage, TResponse>(
    IEnumerable<IValidator<TMessage>> validators
) : IPipelineBehavior<TMessage, TResponse>
    where TMessage : IMessage
    where TResponse : IResult
{
    /// <summary>
    /// Todo: find 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="next"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<TResponse> Handle(
        TMessage message,
        MessageHandlerDelegate<TMessage, TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (!validators.Any()) return await next(message, cancellationToken);

        var context = new ValidationContext<TMessage>(message);

        var validationResults = await Task.WhenAll(
            validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var errors = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (errors.Count == 0) return await next(message, cancellationToken);

        throw new AppValidationException(errors);
    }
}