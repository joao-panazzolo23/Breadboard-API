using Breadboard.Application.Services;

namespace BreadBoard.Infra.JWTBearer;

public class JWTAuthenticationService : IAuthenticationService
{
    public Task<string> GenerateToken(string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}