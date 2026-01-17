using Breadboard.Application.Exceptions.Exceptions;
using Breadboard.Application.Exceptions.Models;
using Breadboard.Presentation.ExceptionHandler;
using Breadboard.Presentation.ExceptionHandler.Strategies;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Presentation.Extensions;

public static class ExceptionHandlerExtensions
{
    public static IServiceCollection AddExceptions(this IServiceCollection services)
    {
        return services
            .AddExceptionHandling()
            .AddExceptionFactory()
            .AddExceptionStrategies();
    }
    private static IServiceCollection AddExceptionStrategies(this IServiceCollection services)
    {
        var types =
           typeof(ExceptionHandlerExtensions).Assembly
           .GetTypes().Where(x => typeof(IExceptionStrategy).IsAssignableFrom(x) && !x.IsAbstract && x.IsClass);

        foreach (var type in types)
        {
            services.AddTransient(typeof(IExceptionStrategy), type);
        }
        return services;

    }
    private static IServiceCollection AddExceptionHandling(this IServiceCollection services)
    {
        return services.AddExceptionHandler<GlobalExceptionHandler>().AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
                context.ProblemDetails.Extensions.Remove("exception");
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
                        errors.Add(new ExceptionDetail(entry.Key, error.ErrorMessage));
                    }
                }
                throw new AppValidationException(errors);
            };
        });
    }
}