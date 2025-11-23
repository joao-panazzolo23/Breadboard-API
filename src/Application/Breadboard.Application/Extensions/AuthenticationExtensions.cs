using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Breadboard.Application.Extensions;

public static class AuthenticationExtensions
{
    /// <summary>
    /// DEU ERRO AQ BIXO, VER QQ TA ROLANDO
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IServiceCollection AddAuthenticationController(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                // options.TokenValidationParameters = new TokenValidationParameters
                // {
                //     ValidateIssuer = true,
                //     ValidateAudience = true,
                //     ValidateLifetime = true,
                //     ValidateIssuerSigningKey = true,
                //     ValidIssuer = builder.Configuration["Jwt:Issuer"],
                //     ValidAudience = builder.Configuration["Jwt:Audience"],
                //     IssuerSigningKey = new SymmetricSecurityKey(
                //         Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                // };
            });
        return builder.Services;
    }
}