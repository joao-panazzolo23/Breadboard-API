using System.ComponentModel.DataAnnotations;

namespace Breadboard.Shared.Options;

public sealed record JwtSettings
{
    [Required]
    public string Issuer { get; set; }
    [Required]
    public string Audience { get; set; }
    [Required]
    [MinLength(32)]
    public string Secret { get; set; }
    [Range(1, int.MaxValue)]
    public int TokenExpirationMinutes { get; set; }
    [Range(1, int.MaxValue)]
    public int RefreshTokenExpirationDays { get; set; }
}
