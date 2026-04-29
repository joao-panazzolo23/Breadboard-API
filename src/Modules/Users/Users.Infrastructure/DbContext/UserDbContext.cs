using Breadboard.Domain.Entities;
using BuildingBlocks.PostgreSQL;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Users.Infrastructure.DbContext;

internal sealed class UserDbContext(DbContextOptions options, IPublisher publisher) : AppDbContext(options, publisher)
{
    public DbSet<User> Users { get; set; }
}
