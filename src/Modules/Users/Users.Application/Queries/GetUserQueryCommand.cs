using Breadboard.Application.ResultPattern;
using Breadboard.Domain.DTOs;
using Mediator;

namespace Users.Application.Queries;

public record GetUserQueryCommand(Guid Id) : ICommand<Result<UserDto>>;