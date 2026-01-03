using Breadboard.Application.Authentication;

namespace BreadBoard.Infra.JWTBearer.Services;

public class PasswordHasher : IPasswordHasher
{
    public bool Verify(string password, string hash) =>
        BCrypt.Net.BCrypt.Verify(password, hash);


    public string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);
}