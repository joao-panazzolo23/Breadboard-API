namespace Breadboard.Application.Services;

/// <summary>
/// I have no clue where to start.
/// </summary>
public interface IAuthenticationService
{
    Task<string> GenerateToken(string username);
    Task<bool> ValidateUser(string username, string password);
}