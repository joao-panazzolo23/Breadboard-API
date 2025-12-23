using System.Text;
using Breadboard.Domain.Services;
using Breadboard.Shared.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
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
    ///
    /// And damn, that's nasty.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static WebApplicationBuilder UseJwtBearer(this WebApplicationBuilder builder)
    {
        var jwtSettings = builder.Configuration
            .GetSection("JwtSettings")
            .Get<JwtSettings>()
            ?? throw new InvalidOperationException("JwtSettings not configured");

        builder.Services.AddSingleton(jwtSettings);

       
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ClockSkew = TimeSpan.Zero
                };
            });

        return builder;
    }

    public static IServiceCollection AddJwtDependencies(this IServiceCollection services)
    {

        services.AddScoped<IJwtAuthService, JwtAuthenticationService>();

        return services;
    }



}