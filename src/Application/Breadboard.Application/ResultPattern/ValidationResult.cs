using System.Net;

namespace Breadboard.Application.ResultPattern;

public sealed class ValidationResult<T> : Result<T>, IValidationResult where T : class
{
    public ValidationResult(HttpStatusCode statusCode, string? message = null) : base(statusCode, message)
    {
    }

    public ValidationResult(HttpStatusCode statusCode, T? data, string? message = null) : base(statusCode, data, message)
    {
    }
}