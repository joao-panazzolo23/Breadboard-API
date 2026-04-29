using Breadboard.Application.ResultPattern;
using Mediator;

namespace Users.Application.Users.Commands;

public record DeleteUserCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}