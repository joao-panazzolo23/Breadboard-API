namespace Breadboard.Domain.Users.DTOs;

public record LoginDto(string token)
{
    public string JwtToken { get; set; } = token;
}