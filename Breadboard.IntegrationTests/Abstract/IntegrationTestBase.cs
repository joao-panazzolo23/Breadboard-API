using Breadboard.IntegrationTests.Configurations;
using Npgsql;
using Respawn;

namespace Breadboard.IntegrationTests.Abstract;

[Collection("Database")]
public class IntegrationTestBase : IAsyncLifetime
{
    protected readonly HttpClient Client;
    protected readonly NpgsqlConnection Db;
    private Respawner _respawner = default!;

    protected IntegrationTestBase(PostgresContainerFixture pg)
    {
        Client = new ApiFactory(pg).CreateClient();
        Db = new NpgsqlConnection(pg.ConnectionString);
    }

    protected virtual string[] Schemas => [];

    public async Task InitializeAsync()
    {
        await Db.OpenAsync();
        _respawner = await Respawner.CreateAsync(Db, new RespawnerOptions
        {
            DbAdapter = DbAdapter.Postgres,
            SchemasToInclude = Schemas
        });
    }

    public async Task DisposeAsync() => await _respawner.ResetAsync(Db);
}