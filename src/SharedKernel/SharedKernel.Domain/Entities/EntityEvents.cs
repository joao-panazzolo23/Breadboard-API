using Breadboard.Shared.Events;

namespace Breadboard.Shared.Entities;

public class EntityEvents
{
    public IList<IDomainEvent> List { get; private set; }

    public EntityEvents Add(IDomainEvent @event)
    {
        this.List.Add(@event);
        return this;
    }

    public EntityEvents Clear(IDomainEvent @event)
    {
        this.List.Clear();
        return this;
    }
    
    public bool Any() => List.Any();
    
}