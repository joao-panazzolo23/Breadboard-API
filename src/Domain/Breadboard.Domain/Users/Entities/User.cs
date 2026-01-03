namespace Breadboard.Domain.Users.Entities;

public class User(
    string password,
    string username,
    string email,
    DateTime? birthDate,
    string? exhibitionName)
    : Entity
{
    public User WithPassword(string hash)
    {
        Password = hash;
        return this;
    }

    public string Password { get; private set; } = password;
    public string Username { get; private set; } = username;
    public string? ExhibitionName { get; private set; } = exhibitionName;
    public DateTime? BirthDate { get; private set; } = birthDate;
    public string Email { get; private set; } = email;
}