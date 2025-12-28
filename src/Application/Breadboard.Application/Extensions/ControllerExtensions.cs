using Breadboard.Application.TransformCase;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Breadboard.Application.Extensions;

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