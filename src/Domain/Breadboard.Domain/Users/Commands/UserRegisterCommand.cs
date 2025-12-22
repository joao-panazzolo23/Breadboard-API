using Breadboard.Domain.Users.Enums;

namespace Breadboard.Domain.Users.Handlers;

public class UserRegisterCommand
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public EGender? Gender { get; set; }
}