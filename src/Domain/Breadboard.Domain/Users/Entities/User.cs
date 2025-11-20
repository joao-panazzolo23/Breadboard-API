using Breadboard.Shared.Entities;

namespace Breadboard.Domain.Users.Entities;

public class User : Entity
{
    public string Password { get; set; }
}