namespace Breadboard.Domain.Authentication;

public interface IPasswordHasher
{
    bool Verify(string password, string passwordHash);
}