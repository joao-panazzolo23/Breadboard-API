using System.Linq.Expressions;
using System.Text;
using Breadboard.Shared.Extensions;

namespace Breadboard.Infra.PostgreSQLDapper.QueryBuilder;

public class Builder<T>
{
    private readonly List<string> _selects = [];
    private readonly List<string> _where = [];
    private readonly List<string> _order = [];
    private string? _from = typeof(T).Name;

    public Builder<T> Select(Expression<Func<T, object>> selector)
    {
        var prop = ExpressionUtils.GetPropName(selector);
        _selects.Add(prop);
        return this;
    }

    public Builder<T> From()
    {
        _from = nameof(T);
        return this;
    }

    public Builder<T> Where(Expression<Func<T, bool>> predicate)
    {
        var body = new SqlExpressionVisitor().Translate(predicate);
        _where.Add(body);
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