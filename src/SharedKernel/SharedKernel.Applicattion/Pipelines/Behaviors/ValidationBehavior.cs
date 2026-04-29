using Breadboard.Application.Exceptions.Exceptions;
using Breadboard.Application.Exceptions.Models;
using FluentValidation;
using Mediator;

namespace Breadboard.Application.Pipelines.Behaviors;

public sealed class ValidationBehavior<TMessage, TResponse>(
    IEnumerable<IValidator<TMessage>> validators
) : IPipelineBehavior<TMessage, TResponse>
    where TMessage : IMessage
{
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

        throw new AppValidationException(errors.Select(x => new ExceptionDetail(x.PropertyName, x.ErrorMessage))
            .ToList());
    }
}