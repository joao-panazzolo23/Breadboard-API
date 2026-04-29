using System.Net;

namespace Breadboard.Application.Exceptions.Models;

public record ExceptionResult(HttpStatusCode StatusCode)
{
    public ExceptionResult(HttpStatusCode StatusCode,
        IEnumerable<ExceptionDetail>? errors,
        string? assembly,
        string message = "One or more errors occurred.") : this(StatusCode)
    {
        Message = message;
        Project = assembly;
        Errors = errors;
    }

    public HttpStatusCode StatusCode { get; private set; } = StatusCode;
    public string? Message { get; private set; }
    public string? Project { get; private set; }
    public IEnumerable<ExceptionDetail>? Errors { get; private set; }
}