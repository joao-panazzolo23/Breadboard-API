using System.Net;
using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace Breadboard.Application.ResultPattern;

/// <summary>
/// Todo: this method is totally coupled with FluentValidation package
/// change ValidationFailure to a custom record and build a mapper extension maybe
/// this is breaking decoupling, 
/// </summary>
/// <param name="statusCode"></param>
/// <param name="data"></param>
/// <param name="message"></param>
/// <param name="errors"></param>
/// <typeparam name="T"></typeparam>
public class Result<T>(
    HttpStatusCode statusCode,
    T? data,
    string? message = null
    // List<ValidationFailure>? errors = null
) : IResult<T>
{
    [JsonIgnore] private readonly HttpStatusCode _statusCode = statusCode;
    [JsonIgnore] public int StatusCode => (int)_statusCode;
    public string? Message { get; private set; } = message;

    public T? Data { get; private set; } = data;
    // public List<ValidationFailure> Errors { get; private set; } = errors ?? new();
    //
    // public IResult HasErrors(ValidationFailure error)
    // {
    //     Errors.Add(error);
    //     return this;
    // }
    //
    // public IResult HasErrors(List<ValidationFailure> error)
    // {
    //     Errors.AddRange(error);
    //     return this;
    // }
}