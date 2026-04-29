namespace Breadboard.Domain.DTOs;

public record UserDto(string Username, string FirstName, string LastName, string Email, string Password)
{
    public Guid Id { get; set; }
    public string Username { get; set; } = Username;

    public string FirstName { get; set; } = FirstName;
    public string LastName { get; set; } = LastName;
    public DateTime BirthDate { get; set; }
    public string Email { get; set; } = Email;
    public string Password { get; set; } = Password;
}