using Breadboard.Domain.Authentication;
using Breadboard.Domain.Services;

namespace BreadBoard.Infra.JWTBearer.Services;

public class PasswordHasher : IPasswordHasher
{
    public bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}