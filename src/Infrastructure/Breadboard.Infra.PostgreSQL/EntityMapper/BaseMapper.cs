using Breadboard.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Breadboard.Infra.PostgreSQL.EntityMapper;

public abstract class BaseMapper<T> : IBaseMapper where T : Entity
{
    public void Apply(ModelBuilder modelBuilder)
    {
        var builder = modelBuilder.Entity<T>();
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        ConfigureMap(builder);
    }

    protected abstract void ConfigureMap(EntityTypeBuilder<T> builder);
}