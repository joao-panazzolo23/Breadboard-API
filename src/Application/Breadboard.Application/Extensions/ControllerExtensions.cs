using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

            //todo: resolver isso aqui
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = apiVersion;
                options.ReportApiVersions = true;
            });

            return services;
        }

        public static WebApplicationBuilder AddControllerNamingConvention(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseParameterTransformer()));
            });

            return builder;
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