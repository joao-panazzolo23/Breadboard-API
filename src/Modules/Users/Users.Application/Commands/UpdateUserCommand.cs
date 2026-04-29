namespace Users.Application.Commands;

public record UpdateUserCommand(
    string Username,
    string Email,
    string Password,
    string ExhibitionName,
    DateTime? BirthDate,
    string? ConfirmPassword) :
    RegisterUserCommand(
        Username,
        Email,
        Password,
        ExhibitionName,
        BirthDate,
        ConfirmPassword);