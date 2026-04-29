using System.Net;
using FluentValidation.Results;

namespace Breadboard.Application.ResultPattern.Factory;

public static class ResultFactory<T>
{
    //todo: implement error returns, consider OneOf or CSharpFunctionalExtensions
    public static Result<T?> Ok(T? data = default, string? message = null) =>
        new(statusCode: HttpStatusCode.OK, data, message);

    public static Result<T?> Unauthorized(T? data = default, string? message = null) =>
        new(statusCode: HttpStatusCode.Unauthorized, data, message);

    public static Result<T?> BadRequest(string? message = null) =>
        new(
            statusCode: HttpStatusCode.BadRequest,
            data: default(T),
            message: message
        );

    public static Result<T?> NotFound(string? message = null) =>
        new(HttpStatusCode.NotFound, default(T), message);

    public static Result<T?> Conflict(string? message = null) =>
        new(HttpStatusCode.Conflict, default(T), message);

    // //special method for validations only
    // public static Result<T?> InvalidRequest()
    // {
    //     return BadRequest();
    // }
}