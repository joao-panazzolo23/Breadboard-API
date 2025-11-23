using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Breadboard.Application.Extensions
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            //get assembly version from csproj 
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(assemblyVersion?.Major ?? 1, assemblyVersion?.Minor ?? 0);
                options.ReportApiVersions = true;
            });

            return services;
        }

        public static IServiceCollection AddControllerNamingConvention(this IServiceCollection services)
        {
            services
                .AddEndpointsApiExplorer()
                .AddControllers(options =>
                {
                    options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseParameterTransformer()));
                    //very bad kebab case implementation
                    //options.Conventions.Add(new RoutePrefixConvention());
                })
                .ConfigureJsonConvention();

            return services;
        }

        public static WebApplication MapEndpoints(this WebApplication application)
        {
            application.MapControllerRoute(
                name: "default",
                pattern: "{controller}"
            );

            return application;
        }
    }
}