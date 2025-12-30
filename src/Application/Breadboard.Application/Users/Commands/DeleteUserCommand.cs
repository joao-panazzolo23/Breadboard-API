namespace Breadboard.Domain.Users.Commands;

public record DeleteUserCommand
{
    public Guid Id { get; set; }
}