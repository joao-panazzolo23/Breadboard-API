using System.Security.Claims;
using Breadboard.Domain.Users.Entities;

namespace Breadboard.Domain.Services;

/// <summary>
/// I have no clue where to start.
/// </summary>
public interface IJwtAuthService
{
    string GenerateToken(User user);
    string RefreshToken(User user);
}