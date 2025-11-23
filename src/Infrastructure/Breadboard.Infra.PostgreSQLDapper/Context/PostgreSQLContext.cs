using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Breadboard.Infra.PostgreSQLDapper.Context;

public abstract class PostgreSqlContext : IDisposable
{
    public readonly IDbConnection Connection;
    public PostgreSqlContext(IConfiguration configuration)
    {
        Connection = new NpgsqlConnection(configuration["DefaultConnection"]);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}