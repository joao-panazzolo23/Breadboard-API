namespace Breadboard.Domain.Users.Commands;

public record UpdateUserCommand(
    string Username,
    string Email,
    string Password,
    string ExhibitionName,
    DateTime? BirthDate) :
        RegisterUserCommand(
            Username,
            Email,
            Password,
            ExhibitionName,
            BirthDate);