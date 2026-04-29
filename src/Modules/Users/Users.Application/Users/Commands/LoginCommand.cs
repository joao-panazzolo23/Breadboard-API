using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.DTOs;
using Mediator;

namespace Users.Application.Users.Commands;

public record LoginCommand(
    string Username,
    string Password
) : ICommand<Result<LoginDto?>>;