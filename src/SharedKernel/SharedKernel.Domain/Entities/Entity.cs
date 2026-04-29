namespace Breadboard.Shared.Entities;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public EntityEvents DomainEvents { get; set; } = new();
    public void SetCreatedAt()
    {
        this.CreatedAt = DateTime.UtcNow;
    }

    public void SetUpdatedAt()
    {
        this.UpdatedAt = DateTime.UtcNow;
    }
}