using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Breadboard.Domain.Services;
using Breadboard.Domain.Users.Entities;
using Breadboard.Shared.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BreadBoard.Infra.JWTBearer.Services;

/// <summary>
/// Todo: refactor this
/// </summary>
/// <param name="jwtSettings"></param>
public class AuthService(IOptions<JwtSettings> jwtSettings) : IJwtAuthService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    private IJwtAuthService _jwtAuthService;

    public string GenerateToken(User user)
    {
        //Role will be related from Users or UserRoles?
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

    public string RefreshToken(User user)
    {
        throw new NotImplementedException();
    }
}