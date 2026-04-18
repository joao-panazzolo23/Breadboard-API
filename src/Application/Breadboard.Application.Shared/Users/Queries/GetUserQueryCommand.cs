using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.DTOs;
using Mediator;

namespace Breadboard.Application.Users.Queries;

public record GetUserQueryCommand(Guid Id) : ICommand<Result<UserDto>>;