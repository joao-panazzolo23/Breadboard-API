using System.Net;
using Breadboard.Shared.Entities;

namespace Breadboard.Shared.Factories;

public static class ResultFactory
{
    //todo: implement error returns, consider OneOf or CSharpFunctionalExtensions
    public static Result<T> Success<T>()
    {
        return new Result<T>()
        {
            StatusCode = HttpStatusCode.OK
        };
    }

    public static Result<T> Success<T>(T data)
    {
        return new Result<T>()
        {
            StatusCode = HttpStatusCode.OK,
            Data = data
        };
    }

    public static Result<T> Error<T>()
    {
        return new Result<T>()
        {
            StatusCode = HttpStatusCode.OK
        };
    }
    
    public static Result<T> Succeded<T>(string message, T data)
    {
        return new Result<T>
        {
            StatusCode = HttpStatusCode.OK,
            Message = message,
            Data = data
        };
    }
    
    public static Result<T> NotFound<T>(string? message = null)
    {
        return new Result<T>
        {
            StatusCode = HttpStatusCode.OK,
            Message = message
        };
    }
}