using Breadboard.Domain.Users.Entities;

namespace Breadboard.Application.Authentication;

/// <summary>
/// I have no clue where to start.
/// </summary>
public interface IJwtAuthService
{
    string GenerateToken(User user);
    string RefreshToken(User user);
}