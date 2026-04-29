using Breadboard.Domain.Entities;

namespace Breadboard.Application.Authentication;

/// <summary>
/// I have no clue where to start.
/// </summary>
public interface ITokenService
{
    string Generate(User user);
    string RefreshToken(User user);
}