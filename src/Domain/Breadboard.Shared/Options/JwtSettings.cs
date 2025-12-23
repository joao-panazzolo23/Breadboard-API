namespace Breadboard.Shared.Options;

public class JwtSettings
{
     public string Issuer { get; set; }
     public string Audience { get; set; }
     public string Secret { get; set; }
     public int TokenExpirationMinutes { get; set; }
     public int RefreshTokenExpirationDays { get; set; }
}