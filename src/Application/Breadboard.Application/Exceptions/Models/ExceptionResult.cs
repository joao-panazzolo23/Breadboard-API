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
        Exceptions = errors;
    }

    public HttpStatusCode StatusCode { get; set; } = StatusCode;
    public string? Message { get; set; } 
    public string? Project { get; set; }
    public IEnumerable<ExceptionDetail>? Exceptions { get; set; }
}