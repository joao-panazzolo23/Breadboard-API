using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.ExceptionHandler;
using Breadboard.Presentation.ExceptionHandler.Exceptions;
using Breadboard.Presentation.ExceptionHandler.Strategies.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Presentation.Extensions;

public static class ExceptionHandlerExtensions
{
    public static IServiceCollection AddExceptions(this IServiceCollection services)
    {
        return services.AddExceptionHandler().AddExceptionFactory().AddExceptionStrategies();
    }

    private static IServiceCollection AddExceptionStrategies(this IServiceCollection services)
    {
        var exceptionType = typeof(IExceptionStrategy);
        
        var types =
            exceptionType.Assembly
                .GetTypes().Where(x => exceptionType.IsAssignableFrom(x) && !x.IsAbstract && x.IsClass);

        foreach (var type in types)
        {
            services.AddTransient(exceptionType, type);
        }

        return services;
    }

    private static IServiceCollection AddExceptionHandler(this IServiceCollection services)
    {
        return services.AddExceptionHandler<GlobalExceptionHandler>().AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
            };
        });
    }

    /// <summary>
    /// If we wanted to customize errors, we could use this function with a property/errors dictionary. 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    private static IServiceCollection AddExceptionFactory(this IServiceCollection services)
    {
        return services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = new List<ExceptionDetail>();
                
                foreach (var entry in context.ModelState)
                {
                    foreach (var error in entry.Value!.Errors)
                    {
                        var apiError = new ExceptionDetail(entry.Key, error.ErrorMessage);
                        errors.Add(apiError);
                    }
                }

                throw new ValidationException(errors);
            };
        });
    }
}