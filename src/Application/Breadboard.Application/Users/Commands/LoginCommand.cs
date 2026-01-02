using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.Viewmodels;
using Mediator;

namespace Breadboard.Application.Users.Commands;

public record LoginCommand(
    string Username,
    string Password, 
    string Token ) : ICommand<Result<LoginViewmodel>>;