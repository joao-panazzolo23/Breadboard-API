using System.Text;
using Breadboard.Application.Authentication;
using BreadBoard.Infra.JWTBearer.Options;
using BreadBoard.Infra.JWTBearer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BreadBoard.Infra.JWTBearer.Extensions;

public static class JwtExtensions
{
    /// <summary>
    /// TODO:This method is doing both configuration for JwtSettings AND Jwt itself.
    ///
    /// And also, I need to make sure it is a secure authorization method as well
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IServiceCollection AddJwtBearerDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var config = configuration.GetSection("JwtSettings");

        services.AddOptions<JwtOptions>()
            .Bind(config)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services.ConfigureJwtToken(config.Get<JwtOptions>()!)
            .AddJwtDependencies();
    }

    /// <summary>
    /// todo: refactor this
    /// </summary>
    /// <param name="services"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    private static IServiceCollection ConfigureJwtToken(
        this IServiceCollection services,
        JwtOptions settings
    )
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = settings.Issuer,
                    ValidAudience = settings.Audience,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(settings.Secret)),
                };
            });

        return services;
    }

    private static IServiceCollection AddJwtDependencies(this IServiceCollection services)
    {
        return services.AddScoped<ITokenService, TokenService>()
            .AddScoped<IPasswordHasher, PasswordHasher>();
    }
}