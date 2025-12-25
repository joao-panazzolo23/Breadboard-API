using Breadboard.Infra.COPS.Extensions;
using System.Reflection;

namespace Breadboard.Application.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddCops(Assembly.GetExecutingAssembly());

        return builder; 
    }
}
