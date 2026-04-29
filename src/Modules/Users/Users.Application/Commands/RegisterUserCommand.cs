using Breadboard.Application.ResultPattern;
using Mediator;

namespace Users.Application.Commands;

public record RegisterUserCommand(
    string Username,
    string Email,
    string Password,
    string ExhibitionName,
    DateTime? BirthDate,
    string? ConfirmPassword) : ICommand<Result<Unit>>;