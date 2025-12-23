using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Breadboard.Domain.Services;
using Breadboard.Domain.Users.Entities;
using Breadboard.Shared.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BreadBoard.Infra.JWTBearer.Services;

public class AuthenticationService(IOptions<JwtSettings> jwtSettings) : IJwtAuthService
{
    private JwtSettings _jwtSettings { get; set; } = jwtSettings.Value;
    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("role", user.Role)
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

    public Task<ClaimsPrincipal> Validate(string token)
    {
        throw new NotImplementedException();
    }
}


