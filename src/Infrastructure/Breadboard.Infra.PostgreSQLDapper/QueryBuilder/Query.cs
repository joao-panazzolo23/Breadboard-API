namespace Breadboard.Infra.PostgreSQLDapper.QueryBuilder;

public static class Query
{
    public static Builder<T> From<T>() => new Builder<T>();
}