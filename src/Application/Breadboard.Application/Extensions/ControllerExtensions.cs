using Breadboard.Application.TransformCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Breadboard.Application.Extensions
{
    public static class ControllerExtensions
    {
        [Obsolete("Use AddControllerNamingConvention()")]
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            //get assembly version from csproj 

            //todo: remove this method and find a way to make it Controller-friendly
            //and not stupidly overengineered getting within assembly
            
            // var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            return services;
        }

        public static IServiceCollection AddControllerNamingConvention(this IServiceCollection services)
        {
            services
                // .AddEndpointsApiExplorer()
                .AddControllers(options =>
                {
                    options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseUrlTransformer()));
                    //very bad kebab case implementation
                    //options.Conventions.Add(new RoutePrefixConvention());
                })
                .ConfigureJsonConvention();

            return services;
        }

        [Obsolete("Use AddControllerNamingConvention()")]
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