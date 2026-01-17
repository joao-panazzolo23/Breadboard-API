using Breadboard.Application.Exceptions.Models;
using FluentValidation.Results;

namespace Breadboard.Application.Exceptions.Exceptions;

public sealed class AppValidationException : Exception
{
    public AppValidationException(IEnumerable<ValidationFailure> failures)
    {
        Errors = failures.Select(x => new ExceptionDetail(x.PropertyName, x.ErrorMessage));
    }

    public AppValidationException(IEnumerable<ExceptionDetail> details)
    {
        Errors = details;
    }

    public IEnumerable<ExceptionDetail> Errors { get; private init; }
}