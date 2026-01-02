
using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.Viewmodels;
using Mediator;

namespace Breadboard.Application.Users.Commands;

public record RegisterUserCommand(
    string Username,
    string Email,
    string Password,
    string ExhibitionName,
    DateTime? BirthDate,
    string? ConfirmPassword) : ICommand<Result<LoginViewmodel>>;