namespace Breadboard.Domain.Services;

public interface IPasswordHasher
{
    bool Verify(string password, string passwordHash);
}