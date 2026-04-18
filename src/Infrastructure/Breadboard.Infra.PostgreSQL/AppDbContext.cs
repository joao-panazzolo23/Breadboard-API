using Breadboard.Domain;
using Breadboard.Domain.Users.Entities;
using Breadboard.Shared.Entities;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Breadboard.Infra.PostgreSQL;

public class AppDbContext(
    DbContextOptions<AppDbContext> options,
    IPublisher publisher
) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken)
    {
        var entries = ChangeTracker.Entries<Entity>().ToList();

        SetCustomDates(entries);

        await PublishEvents(entries);

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void SetCustomDates(List<EntityEntry<Entity>> entries)
    {
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.SetCreatedAt();
                    break;
                case EntityState.Modified:
                    entry.Entity.SetUpdatedAt();
                    break;
            }
        }
    }

    private Task PublishEvents(IEnumerable<EntityEntry<Entity>> entries)
    {
        var events = entries.SelectMany(x => x.Entity.DomainEvents.List)
            .ToList();

        foreach (var @event in events)
        {
            publisher.Publish(@event);
        }

        return Task.CompletedTask;
    }
}