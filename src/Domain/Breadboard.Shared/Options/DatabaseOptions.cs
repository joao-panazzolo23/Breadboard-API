using System.ComponentModel.DataAnnotations;

namespace Breadboard.Shared.Options;

public sealed record DatabaseOptions
{
    [Required]
    public string DefaultConnection { get; init; } = null!;
}
