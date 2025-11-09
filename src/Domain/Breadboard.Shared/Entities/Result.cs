using System.Net;

namespace Breadboard.Shared.Entities;

public class Result<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    // public List<ResultError>? Errors { get; set; }
}