using Breadboard.Infra.COPS.Extensions;
using System.Reflection;
using Breadboard.Domain.Users.Entities;

namespace Breadboard.Presentation.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddCops(typeof(User).Assembly);

        return builder;
    }
}