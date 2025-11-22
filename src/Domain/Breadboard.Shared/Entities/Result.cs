using System.Net;
using System.Text.Json.Serialization;

namespace Breadboard.Shared.Entities;

/// <summary>
/// Results SHOULDN'T be created manually. They should be created at Result Factories for standard-keeping.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Result<T>
{
    public Result(HttpStatusCode statusCode, T data, string message = null)
    {
        _statusCode = statusCode;
        Data = data;
        Message = message; 
    }
    public Result(HttpStatusCode statusCode, string? message = null)
    {
        _statusCode = statusCode;
        Message = message; 
    }
    
    [JsonIgnore] private readonly HttpStatusCode _statusCode;
    [JsonIgnore] public int StatusCode => (int)_statusCode ;  
    public string? Message { get; set; }
    public T? Data { get; set; }
    
    // public List<ResultError>? Errors { get; set; }
}