using System.Linq.Expressions;
using System.Text;

namespace Breadboard.Infra.PostgreSQLDapper.QueryBuilder;

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
        if (node.Left is not MemberExpression { Expression: ParameterExpression } left)
            throw new NotSupportedException(nameof(Translate));

        var columnName = left.Member.Name;
        
        _sql.Append(columnName);
        _sql.Append(GetSqlOperator(node.NodeType));
        _sql.Append("@").Append(columnName.ToLower());

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
}