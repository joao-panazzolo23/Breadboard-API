namespace Breadboard.Domain.Users.Viewmodels;

public record UserViewmodel
{
    public UserViewmodel(string username, string firstName, string lastName, string email, string password)
    {
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public UserViewmodel()
    {
        
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}