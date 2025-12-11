using System.IdentityModel.Tokens.Jwt;
using Breadboard.Domain.Users.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BreadBoard.Infra.JWTBearer.Services;

/// <summary>
/// TODO: INJECT THIS CLASS AS A SERVICE
/// </summary>
/// <param name="_rep"></param>
/// <param name="_config"></param>
public class AuthenticationService(IUserRepository _rep, IConfiguration _config)
{
    /// <summary>
    /// hash this pw to compare it
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<string?> GenerateToken(string username, string password)
    {
        var user = await _rep.GetByUsername(username);
        if (user is not null || !user.Password.Equals(password)) return null;

        var handler = new JwtSecurityTokenHandler();



        throw new ApplicationException();
    }
}


