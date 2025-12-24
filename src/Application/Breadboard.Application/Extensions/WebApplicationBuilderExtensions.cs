using Breadboard.Infra.COPS.Extensions;
using System.Reflection;

namespace Breadboard.Application.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.AddSecurity()
               .AddDatabase()
               .AddDocuments()
               .AddControllersScheme()
               .AddCaching()
               .AddMediator();
    }

    public static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddCops(Assembly.GetExecutingAssembly());

        return builder; 
    }
}
