using BuildingBlocks.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace Breadboard.IntegrationTests.Configurations;

public sealed class PostgresContainerFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _container = new PostgreSqlBuilder("postgres:16-alpine")
        .Build();

    public ApiFactory Factory { get; private set; } = default!;

    public string ConnectionString => _container.GetConnectionString();

    public async Task InitializeAsync()
    {
        await _container.StartAsync();
        Factory = new ApiFactory(this);
        await RunMigrationsAsync();
    }
    public async Task DisposeAsync()
        => await _container.DisposeAsync();

    private async Task RunMigrationsAsync()
    {
        var factory = new ApiFactory(this);
        await using var scope = factory.Services.CreateAsyncScope();
        var sp = scope.ServiceProvider;

        await sp.GetRequiredService<AppDbContext>().Database.MigrateAsync();
    }
}

