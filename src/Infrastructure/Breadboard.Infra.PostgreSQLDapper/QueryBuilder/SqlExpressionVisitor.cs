using System.Linq.Expressions;
using System.Text;

namespace BuildingBlocks.PostgreSQLDapper.QueryBuilder;

internal class SqlExpressionVisitor : ExpressionVisitor
{
    private readonly StringBuilder _sql = new();
    private readonly Dictionary<string, object?> _params = new();

    public SqlCondition Translate(Expression exp)
    {
        Visit(exp);
        return new SqlCondition(_sql.ToString(), _params);
    }


    protected override Expression VisitBinary(BinaryExpression node)
    {

        Visit(node.Left);

        _sql.Append($" {GetSqlOperator(node.NodeType)} ");

        Visit(node.Right);

        return node;
    }

    private static string GetSqlOperator(ExpressionType type) => type switch
    {
        ExpressionType.Equal => " = ",
        ExpressionType.NotEqual => " <> ",
        ExpressionType.GreaterThan => " > ",
        ExpressionType.GreaterThanOrEqual => " >= ",
        ExpressionType.LessThan => " < ",
        ExpressionType.LessThanOrEqual => " <= ",
        _ => throw new NotSupportedException(type.ToString())
    };

    protected override Expression VisitConstant(ConstantExpression node)
    {
        _sql.Append(node.Value);
        return node;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        if (node.Expression is ParameterExpression)
        {
            _sql.Append($"\"{node.Member.Name}\"");
            return node;
        }
        
        var columnName = node.Member.Name;
        var value = GetValue(node);

        var paramName = $"@{columnName}";
        _params[paramName] = value;

        _sql.Append(paramName);
        return node;
    }
    private static object? GetValue(MemberExpression member)
    {
        // Compila e executa a expressão
        var objectMember = Expression.Convert(member, typeof(object));
        var getter = Expression.Lambda<Func<object?>>(objectMember).Compile();
        return getter();
    }
}