using System.Linq.Expressions;
using System.Reflection;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.ResultPattern.Factory;
using FluentValidation.Results;

namespace Breadboard.Application.ValidationPipeline.Factory;

//Todo: find a way to remove reflections and use a custom wrapper
internal static class ResultCache<TResponse> where TResponse : IResult
{
    private static readonly Func<List<ValidationFailure>, TResponse> Factory = BuildFactory();

    private static Func<List<ValidationFailure>, TResponse> BuildFactory()
    {
        var typeArg = typeof(TResponse).GetGenericArguments()[0];
        var factoryType = typeof(ResultFactory<>).MakeGenericType(typeArg);
        //using this secures name binding by property
        var methodName = nameof(ResultFactory<object>.BadRequest);
        var method = factoryType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static)!;

        var errorsParam = Expression.Parameter(typeof(List<ValidationFailure>), "errors");

        var call = Expression.Call(
            method,
            Expression.Constant(null, typeof(string)),
            Expression.Convert(errorsParam, typeof(List<ValidationFailure>))
        );

        var lambda = Expression.Lambda<Func<List<ValidationFailure>, TResponse>>(
            call,
            errorsParam
        );

        return lambda.Compile();
    }

    public static TResponse CreateBadRequest(List<ValidationFailure> errors) => Factory(errors);
}