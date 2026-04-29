namespace BuildingBlocks.PostgreSQLDapper.QueryBuilder;

internal static class Query
{
    public static Builder<T> From<T>() => new Builder<T>();
}