using System.Security.Claims;
using System.Text;
using Breadboard.Application.Authentication;
using Breadboard.Domain.Users.Entities;
using BreadBoard.Infra.JWTBearer.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace BreadBoard.Infra.JWTBearer.Services;

/// <summary>
/// Todo: refactor this
/// </summary>
/// <param name="jwtSettings"></param>
internal class TokenService(
    IOptions<JwtOptions> jwtSettings
) : ITokenService
{
    private readonly JwtOptions _jwtSettings = jwtSettings.Value;
    private ITokenService _tokenService;

    public string Generate(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Email, user.Email),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationMinutes),
            SigningCredentials = credentials
        };
        
        var handler = new JsonWebTokenHandler();
        return handler.CreateToken(tokenDescriptor);
    }

    //todo: create a refresh token 
    public string RefreshToken(User user)
    {
        throw new NotImplementedException();
    }
}