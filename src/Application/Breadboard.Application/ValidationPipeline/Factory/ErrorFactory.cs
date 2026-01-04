using Breadboard.Application.ResultPattern;
using FluentValidation.Results;

namespace Breadboard.Application.ValidationPipeline.Factory;

public static class ErrorFactory
{
    public static TResponse InvalidRequest<TResponse>(List<ValidationFailure> errors)
        where TResponse : IResult
    {
        return ResultCache<TResponse>.CreateBadRequest(errors);
    }
}




//Todo: find a way to DO NOT use reflections
// public static class ErrorFactory
// {
//     public static TResponse InvalidRequest<TResponse>(List<ValidationFailure> errors)
//         where TResponse : IResult
//     {
//         return ResultCache<TResponse>.CreateBadRequest(errors);
//     }
//
//     private static class ResultCache<TResponse> where TResponse : IResult
//     {
//         private static readonly Func<List<ValidationFailure>, TResponse> Factory = BuildFactory();
//
//         private static Func<List<ValidationFailure>, TResponse> BuildFactory()
//         {
//             var tResponseType = typeof(TResponse);
//             
//             var innerType = tResponseType.GetGenericArguments()[0];
//             
//             var factoryType = typeof(ResultFactory<>).MakeGenericType(innerType);
//             var method = factoryType.GetMethod("BadRequest", BindingFlags.Public | BindingFlags.Static)!;
//             
//             return (Func<List<ValidationFailure>, TResponse>)
//                 Delegate.CreateDelegate(typeof(Func<List<ValidationFailure>, TResponse>), method);
//         }
//
//         public static TResponse CreateBadRequest(List<ValidationFailure> errors) => Factory(errors);
//     }
// }