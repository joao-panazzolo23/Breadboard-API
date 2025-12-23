using Breadboard.Shared.Entities;

namespace Breadboard.Domain.Users.Entities;

public class User : Entity
{
    public string Password { get; set; }
    public string Username { get; set; }
    public string? ExhibitionName { get; set; }
    public DateTime? BirthDate { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}