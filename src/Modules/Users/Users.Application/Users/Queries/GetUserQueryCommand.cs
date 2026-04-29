using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.DTOs;
using Mediator;

namespace Users.Application.Users.Queries;

public record GetUserQueryCommand(Guid Id) : ICommand<Result<UserDto>>;