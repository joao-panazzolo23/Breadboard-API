using Breadboard.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Breadboard.Infra.PostgreSQL.EntityMapper;

public abstract class BaseMapper<T> : IEntityTypeConfiguration<T> where T : Entity
{
    protected abstract void ConfigureMap(EntityTypeBuilder<T> builder);

    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        builder.Ignore(x => x.DomainEvents);
        ConfigureMap(builder);
    }
}