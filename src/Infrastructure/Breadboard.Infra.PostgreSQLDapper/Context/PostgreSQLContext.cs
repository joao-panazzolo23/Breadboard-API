using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Breadboard.Infra.PostgreSQLDapper.Context;

/// <summary>
/// THIS CLASS WASN'T SUPPOSED TO BE ABSTRACT? ofc not what am I doing
/// </summary>
public class PostgreSqlContext : IDisposable
{
    public readonly IDbConnection Connection;
    /// <summary>
    /// Todo: is creating a connection every time we instantiate this class viable?
    /// sometimes it can don't even make a query
    /// </summary>
    /// <param name="configuration"></param>
    public PostgreSqlContext(IConfiguration configuration)
    {
        Connection = new NpgsqlConnection(configuration[@"ConnectionStrings:DefaultConnection"]);
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}