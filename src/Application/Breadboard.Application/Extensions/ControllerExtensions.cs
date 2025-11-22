using System.Reflection;
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
            var apiVersion = new ApiVersion(assemblyVersion?.Major ?? 1, assemblyVersion?.Minor ?? 0);

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = apiVersion;
                options.ReportApiVersions = true;
            });

            return services;
        }

        public static IServiceCollection AddControllerNamingConvention(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseParameterTransformer()));
            });

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