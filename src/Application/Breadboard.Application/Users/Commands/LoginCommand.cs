using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.DTOs;
using Mediator;

namespace Breadboard.Application.Users.Commands;

public record LoginCommand(
    string Username,
    string Password
) : ICommand<Result<LoginDto?>>;