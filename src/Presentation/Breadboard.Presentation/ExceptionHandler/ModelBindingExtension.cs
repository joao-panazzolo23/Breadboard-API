using System.Net;
using Breadboard.Application.Exceptions.Exceptions;
using Breadboard.Application.Exceptions.Models;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Presentation.ExceptionHandler;

public static class ModelBindingExtension
{
    /// <summary>
    /// Configures the application to throw a ValidationException containing detailed model binding errors when model
    /// validation fails during API requests.
    /// </summary>
    /// <remarks>This method replaces the default behavior for invalid model state responses in ASP.NET Core
    /// APIs. Instead of returning a 400 Bad Request response, it throws a ValidationException containing all model
    /// validation errors. This can be useful for global exception handling scenarios where you want to process
    /// validation errors in a centralized way.</remarks>
    /// <param name="services">The IServiceCollection to add the model binding exception behavior to.</param>
    /// <returns>The IServiceCollection instance with the model binding exception behavior configured.</returns>
    /// <exception cref="ValidationException">Thrown when a request contains invalid model state. The exception includes all validation errors encountered
    /// during model binding.</exception>
    public static IServiceCollection AddModelBindingExceptions(this IServiceCollection services)
    {
        return services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var errors = context.ModelState
                    .Where(ms => ms.Value?.Errors.Count > 0)
                    .SelectMany(ms =>
                    {
                        var field = ms.Key;

                        return ms.Value!.Errors.Select(error =>
                            new ExceptionDetail(
                                field,
                                error.ErrorMessage.ToLower()
                            )
                        );
                    })
                    .ToArray();

                return new BadRequestObjectResult(
                    new ExceptionResult(
                        HttpStatusCode.BadRequest,
                        errors,
                        typeof(AppValidationException).Assembly.GetName().Name
                    )
                );
            };
        });
    }
}