using Breadboard.Application.ResultPattern;
using Breadboard.Domain.DTOs;
using Mediator;

namespace Users.Application.Commands;

public record LoginCommand(
    string Username,
    string Password
) : ICommand<Result<LoginDto?>>;