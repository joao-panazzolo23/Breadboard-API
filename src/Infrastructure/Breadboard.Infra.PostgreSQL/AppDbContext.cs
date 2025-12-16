using Breadboard.Infra.PostgreSQL.EntityMapper;
using Microsoft.EntityFrameworkCore;

namespace Breadboard.Infra.PostgreSQL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    //Todo: test this function, i'm not sure if it works ok
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.RegisterAllMaps();
    }
}