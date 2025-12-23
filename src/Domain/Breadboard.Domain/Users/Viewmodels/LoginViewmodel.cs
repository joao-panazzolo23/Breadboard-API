namespace Breadboard.Domain.Users.Viewmodels;

public record LoginViewmodel(string token)
{
    public string JwtToken { get; set; } = token;
}