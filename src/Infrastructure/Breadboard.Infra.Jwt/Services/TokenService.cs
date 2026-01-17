using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Breadboard.Application.Authentication;
using Breadboard.Domain.Users.Entities;
using BreadBoard.Infra.JWTBearer.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BreadBoard.Infra.JWTBearer.Services;

/// <summary>
/// Todo: refactor this
/// </summary>
/// <param name="jwtSettings"></param>
internal class AuthService(
    IOptions<JwtOptions> jwtSettings
    ) : IJwtAuthService
{
    private readonly JwtOptions _jwtSettings = jwtSettings.Value;
    private IJwtAuthService _jwtAuthService;

    public string Generate(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, user.Role)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationMinutes),
            signingCredentials: signInCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    //todo: create a refresh token 
    public string RefreshToken(User user)
    {
        throw new NotImplementedException();
    }
}