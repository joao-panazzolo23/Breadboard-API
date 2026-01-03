using System.Net;
using System.Text.Json.Serialization;

namespace Breadboard.Application.ResultPattern;

/// <summary>
/// Results SHOULDN'T be created manually. They should be created at Result Factories for standard-keeping.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Result<T>(HttpStatusCode statusCode, T? data, string? message = null)
{
    public Result(HttpStatusCode statusCode, string? message = null) : this(statusCode, default(T?), message)
    {
    }
    
    [JsonIgnore] private readonly HttpStatusCode _statusCode = statusCode;
    [JsonIgnore] public int StatusCode => (int)_statusCode ;  
    public string? Message { get; set; } = message;

    public T? Data { get; set; } = data;
    // public List<ResultError>? Errors { get; set; }
}