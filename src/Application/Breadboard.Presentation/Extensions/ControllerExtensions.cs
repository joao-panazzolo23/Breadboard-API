using Breadboard.Presentation.TransformCase;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Breadboard.Presentation.Extensions;

public static class ControllerExtensions
{
    public static WebApplicationBuilder AddControllersScheme(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseUrlTransformer()));
            })
            .ConfigureJsonConvention();

        return builder;
    }
}