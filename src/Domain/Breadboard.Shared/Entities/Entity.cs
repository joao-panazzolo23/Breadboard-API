namespace Breadboard.Shared.Entities;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } =  DateTime.Now;
    /// <summary>
    /// Only populated once entity is really updated?
    /// </summary>
    public DateTime UpdatedAt { get; set; } 
}