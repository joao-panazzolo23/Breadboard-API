using Testcontainers.PostgreSql;

namespace Breadboard.IntegrationTests.Configurations;

public class ApiContainerFactory : IAsyncLifetime
{
    private readonly PostgreSqlContainer _db =
        new PostgreSqlBuilder("postgres:16-alpine")
            .Build();

    public async Task InitializeAsync()
    {
        await _db.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _db.DisposeAsync();
    }
}