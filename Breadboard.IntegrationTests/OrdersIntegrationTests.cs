using Npgsql;
using Respawn;

namespace Breadboard.IntegrationTests;

[Collection("Database")]
public class OrdersIntegrationTests(
    HttpClient client,
    NpgsqlConnection db
) : IAsyncLifetime
{
    private readonly HttpClient _client = client;
    private Respawner _respawner = default!;

    public async Task InitializeAsync()
    {
        await db.OpenAsync();
        _respawner = await Respawner.CreateAsync(db, new RespawnerOptions
        {
            DbAdapter = DbAdapter.Postgres,
            SchemasToInclude = ["expenses"]
        });
    }

    public async Task DisposeAsync() => await _respawner.ResetAsync(db);
}