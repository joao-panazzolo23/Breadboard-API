namespace Breadboard.Domain.DTOs;

public record LoginDto(string token)
{
    public string JwtToken { get; set; } = token;
}