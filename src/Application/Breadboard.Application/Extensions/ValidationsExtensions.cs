using FluentValidation;

namespace Breadboard.Application.Extensions;

internal static class ValidationsExtensions
{
    public static WebApplicationBuilder AddValidations(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        return builder;
    }
}