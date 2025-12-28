using System.Text;
using Breadboard.Domain.Services;
using BreadBoard.Infra.JWTBearer.Services;
using Breadboard.Shared.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
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
    public static WebApplicationBuilder AddJwtBearerDependencies(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration.GetSection("JwtSettings");

        builder.Services.AddOptions<JwtSettings>()
            .Bind(config)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services.ConfigureJwtToken(config.Get<JwtSettings>()!)
            .AddJwtDependencies();

        return builder;
    }

    /// <summary>
    /// todo: refactor this
    /// </summary>
    /// <param name="services"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    private static IServiceCollection ConfigureJwtToken(this IServiceCollection services, JwtSettings settings)
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
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(settings.Secret)),
                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }

    private static IServiceCollection AddJwtDependencies(this IServiceCollection services)
    {
        return services.AddScoped<IJwtAuthService, AuthService>()
                       .AddScoped<Breadboard.Domain.Authentication.IPasswordHasher, PasswordHasher>();
        
    }
}