using System.Xml.Schema;
using Breadboard.Domain.Users.Entities;
using Breadboard.Infra.PostgreSQL.EntityMapper;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Breadboard.Infra.PostgreSQL.Mappings;

public class UserMap : BaseMapper<User>
{
    /// <summary>
    /// Todo: find a way to stupidly overengineer this
    /// </summary>
    /// <param name="builder"></param>
    protected override void ConfigureMap(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.BirthDate);
        builder.Property(x => x.ExhibitionName);
        builder.Property(x => x.Password);
        builder.Property(x => x.Username);
    }
}