using System.Linq.Expressions;
using System.Text;
using Breadboard.Shared.Extensions;

namespace Breadboard.Infra.PostgreSQLDapper.QueryBuilder;

internal class Builder<T>
{
    private readonly List<string> _selects = [];
    private readonly List<string> _where = [];
    private readonly List<string> _order = [];
    private string? _from = $"\"{typeof(T).Name}\"";
    private readonly Dictionary<string, object?> _parameters = new();

    //find a way to type this without object
    public Builder<T> Select(Expression<Func<T, object>> selector)
    {
        var prop = ExpressionUtils.GetPropName(selector);
        _selects.Add($"\"{prop}\"");
        return this;
    }
    
    //kinda unnecessary 
    public Builder<T> From()
    {
        _from = $"""{nameof(T)}""";
        return this;
    }

    /// <summary>
    /// todo: add @ before params for Dapper params replacement
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public Builder<T> Where(Expression<Func<T, bool>> predicate)
    {
        //actually this is just transforming a lambda to a SQL condition
        var condition = new SqlExpressionVisitor().Translate(predicate);

        _where.Add(condition.Sql);

        foreach (var p in condition.Parameters)
            _parameters[p.Key] = p.Value;

        return this;
    }

    public Builder<T> OrderBy(Expression<Func<T, object>> selector)
    {
        var prop = ExpressionUtils.GetPropName(selector);
        _order.Add(prop);
        return this;
    }

    public string Build()
    {
        var sb = new StringBuilder();

        sb.Append("SELECT ");

        if (_selects.Count == 0) //that's very bad actually, we are not supposed to use *  
            sb.Append("*");
        else
            sb.Append(string.Join(", ", _selects));

        sb.Append(" FROM " + _from);

        if (_where.Count > 0)
            sb.Append(" WHERE " + string.Join(" AND ", _where));

        if (_order.Count > 0)
            sb.Append(" ORDER BY " + string.Join(", ", _order));

        return sb.ToString();
    }
}