namespace Breadboard.Domain.Users.Commands;

public record LoginCommand(
    string Username,
    string Password);