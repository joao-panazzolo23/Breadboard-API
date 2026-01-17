using Breadboard.Domain.Users.Entities;
using Breadboard.Infra.PostgreSQL.EntityMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Breadboard.Infra.PostgreSQL.Mappings;

public class Users : BaseMapper<User>
{
    protected override void ConfigureMap(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.Property(x => x.BirthDate);
        builder.Property(x => x.ExhibitionName);
        builder.Property(x => x.Password);
        builder.Property(x => x.Username);
        builder.Property(x => x.Email);
    }
}