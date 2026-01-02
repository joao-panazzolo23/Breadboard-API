using Breadboard.Application.ResultPattern;
using Mediator;

namespace Breadboard.Application.Users.Commands;

public record DeleteUserCommand : IRequest<Result<Unit>>
{
    public Guid Id { get; set; }
}