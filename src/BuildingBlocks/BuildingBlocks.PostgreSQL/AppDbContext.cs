using Breadboard.Shared.Entities;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BuildingBlocks.PostgreSQL;

public class AppDbContext(
    DbContextOptions options,
    IPublisher publisher
) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder builder)
    {
        ///todo: migrations will be segregated by modules, it wouldnt work right here.
        ///
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default
    )
    {
        var entries = ChangeTracker.Entries<Entity>().ToList();

        SetCustomDates(entries);

        await PublishEvents(entries, cancellationToken);

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private static void SetCustomDates(List<EntityEntry<Entity>> entries)
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

    /// <summary>
    /// TODO: OUTBOX PATTERN
    /// </summary>
    /// <param name="entries"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private Task PublishEvents(IEnumerable<EntityEntry<Entity>> entries, CancellationToken token)
    {
        var events = entries.SelectMany(x => x.Entity.DomainEvents.List)
            .ToList();

        foreach (var @event in events)
        {
            publisher.Publish(@event, token);
        }

        return Task.CompletedTask;
    }
}