using System.Net;
using Breadboard.Shared.Cops;

namespace Breadboard.Shared.Results;

public static class Results
{
    //todo: implement error returns, consider OneOf or CSharpFunctionalExtensions
    public static Result<T?> Ok<T>(T? data = default, string? message = null) =>
        new(statusCode: HttpStatusCode.OK, data, message);
    public static Result<T> Unauthorized<T>(T? data = default, string? message = null) =>
        new(statusCode: HttpStatusCode.Unauthorized, data, message);
    public static Result<T> Error<T>(string? message = null) => 
        new(statusCode: HttpStatusCode.BadRequest, message);
    public static Result<T> NotFound<T>(string? message = null) => 
        new(HttpStatusCode.NotFound, message);
    public static Result<T> Conflict<T>(string? message = null) => 
        new(HttpStatusCode.Conflict, message);
    public static Result<Nothing> Unauthorized(string? message = null) =>
        new(statusCode: HttpStatusCode.Unauthorized, message);
    public static Result<Nothing> NotFound(string? message = null) =>
        Results.NotFound<Nothing>(message);
}