namespace Breadboard.Shared.Extensions;

/// <summary>
/// This was an exception to query builder, when we want to use dates to filter.
/// </summary>
public static class QueryBuilderExtensions
{
    public static bool Between<T>(this T value, T start, T end) =>
        Comparer<T>.Default.Compare(value, start) >= 0 &&
        Comparer<T>.Default.Compare(value, end) <= 0;
}