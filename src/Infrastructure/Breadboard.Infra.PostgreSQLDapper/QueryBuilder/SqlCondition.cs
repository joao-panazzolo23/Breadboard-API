namespace BuildingBlocks.PostgreSQLDapper.QueryBuilder;

public sealed class SqlCondition
{
    public string Sql { get; }
    public IDictionary<string, object?> Parameters { get; }

    public SqlCondition(string sql, IDictionary<string, object?> parameters)
    {
        Sql = sql;
        Parameters = parameters;
    }
}