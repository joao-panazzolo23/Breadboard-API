using System.ComponentModel.DataAnnotations;

namespace Breadboard.Shared.Options;
/// <summary>
/// Matter of fact, this is supposed to be created inside database project, even using CQRS.
/// </summary>
public sealed record DatabaseOptions
{
    [Required]
    public string DefaultConnection { get; init; } = null!;
}
