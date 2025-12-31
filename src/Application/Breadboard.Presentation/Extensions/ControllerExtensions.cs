using Breadboard.Presentation.TransformCase;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Breadboard.Presentation.Extensions;

public static class ControllerExtensions
{
    public static IServiceCollection AddControllersScheme(this IServiceCollection services)
    {
        services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseUrlTransformer()));
            })
            .ConfigureJsonConvention();

        return services;
    }
}