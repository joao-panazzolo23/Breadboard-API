using Breadboard.Shared.Entities;

namespace Breadboard.Domain.Users.Entities;

public class User : Entity
{
    public User(
        string password, 
        string username,
        string email,
        string role, 
        DateTime? birthDate, 
        string? exhibitionName)
    {
        Password = password;
        Username = username;
        Email = email;
        Role = role;
        BirthDate = birthDate;
        ExhibitionName = exhibitionName;
    }
    public string Password { get; private set; }
    public string Username { get; private set; }
    public string? ExhibitionName { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public string Email { get; private set; }
    public string Role { get; private set; }
}