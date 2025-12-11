using System.Net;
using Breadboard.Shared.Entities;

namespace Breadboard.Shared.Factories;

public static class Result
{
    //todo: implement error returns, consider OneOf or CSharpFunctionalExtensions
    public static TypedResult<T?> Success<T>(T? data = default, string message = null)
    {
        return new TypedResult<T?>(statusCode: HttpStatusCode.OK, data, message);
    }
    public static TypedResult<T?> Unauthorized<T>(T? data = default, string message = null)
    {
        return new TypedResult<T?>(statusCode: HttpStatusCode.Unauthorized, data, message);
    }
    public static TypedResult<T> Error<T>(string? message = null)
    {
        return new TypedResult<T>(statusCode: HttpStatusCode.BadRequest, message);
    }
    public static TypedResult<T> NotFound<T>(string? message = null)
    {
        return new TypedResult<T>(HttpStatusCode.NotFound, message);
    }
    public static TypedResult<T> Conflict<T>(string? message = null)
    {
        return new TypedResult<T>(HttpStatusCode.Conflict, message);
    }
    
}