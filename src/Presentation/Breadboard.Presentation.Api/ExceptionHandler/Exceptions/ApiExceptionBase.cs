using Breadboard.Application.Exceptions.Models;

namespace Breadboard.Presentation.ExceptionHandler.Exceptions;

public abstract class ApiExceptionBase : Exception
{
    public IEnumerable<ExceptionDetail> Errors { get; }

    protected ApiExceptionBase(IEnumerable<ExceptionDetail> errors)
    {
        Errors = errors;
    }

    public virtual string Type { get; } = typeof(ApiExceptionBase).GetType().Name;
}