using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Breadboard.Infra.PostgreSQLDapper.Context;

public class PostgreSQLContext : IDisposable
{
    public IDbConnection _connection;

    public PostgreSQLContext(IConfiguration configuration)
    {
        _connection = new NpgsqlConnection(configuration["DefaultConnection"]);
        _connection.Open();
    }
    public void Dispose() => _connection?.Dispose();
}