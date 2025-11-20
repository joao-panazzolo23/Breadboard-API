using System.Net;
using Breadboard.Shared.Entities;

namespace Breadboard.Shared.Factories;

public static class ResultFactory
{
    //todo: implement error returns, consider OneOf or CSharpFunctionalExtensions
    public static Result<T?> Success<T>(T? data = default, string message = null)
    {
        return new Result<T?>(statusCode: HttpStatusCode.OK, data, message);
    }
    public static Result<T?> Unauthorized<T>(T? data = default, string message = null)
    {
        return new Result<T?>(statusCode: HttpStatusCode.Unauthorized, data, message);
    }
    public static Result<T> Error<T>(string? message = null)
    {
        return new Result<T>(statusCode: HttpStatusCode.BadRequest, message);
    }
    public static Result<T> NotFound<T>(string? message = null)
    {
        return new Result<T>(HttpStatusCode.NotFound, message);
    }
}