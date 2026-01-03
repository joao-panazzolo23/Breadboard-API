namespace Breadboard.Domain.Users.Entities;

public class User : Entity
{
    public User(
        string password,
        string username,
        string email,
        DateTime? birthDate,
        string? exhibitionName)
    {
        Password = password;
        Username = username;
        Email = email;
        BirthDate = birthDate;
        ExhibitionName = exhibitionName;
    }

    public User WithPassword(string hash)
    {
        Password = hash;
        return this;
    }

    public string Password { get; private set; }
    public string Username { get; private set; }
    public string? ExhibitionName { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public string Email { get; private set; }
}