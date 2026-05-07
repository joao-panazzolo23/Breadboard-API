using Breadboard.IntegrationTests.Configurations;
using BuildingBlocks.PostgreSQL;
using Dapper;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Respawn;

namespace Breadboard.IntegrationTests.Abstract;

[Collection("Database")]
public class IntegrationTestBase : IAsyncLifetime
{
    protected readonly HttpClient Client;
    protected readonly NpgsqlConnection Db;
    private Respawner _respawner = default!;
    private readonly AppDbContext context = default!;

    protected IntegrationTestBase(PostgresContainerFixture pg)
    {
        Client = pg.Factory.CreateClient();
        Db = new NpgsqlConnection(pg.ConnectionString);
    }

    protected virtual string[] Schemas => [];

    public async Task InitializeAsync()
    {
        await Db.OpenAsync();

        _respawner = await Respawner.CreateAsync(Db, new RespawnerOptions
        {
            DbAdapter = DbAdapter.Postgres,
            SchemasToInclude = Schemas,
            TablesToIgnore =
            [
              "__EFMigrationsHistory"
            ]
        });

        await context.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        await _respawner.ResetAsync(Db);
        await Db.DisposeAsync();
        Client.Dispose();
    }
}