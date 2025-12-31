namespace Breadboard.Application.Authentication;

public interface IPasswordHasher
{
    bool Verify(string password, string passwordHash);
}