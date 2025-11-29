using System.Linq.Expressions;
using System.Text;

namespace Breadboard.Infra.PostgreSQLDapper.QueryBuilder;

public class SqlExpressionVisitor : ExpressionVisitor
{
    private StringBuilder _sql = new();

    public string Translate(Expression exp)
    {
        Visit(exp);
        return _sql.ToString();
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        _sql.Append("(");
        Visit(node.Left);

        _sql.Append(node.NodeType switch
        {
            ExpressionType.Equal => " = ",
            ExpressionType.GreaterThan => " > ",
            ExpressionType.GreaterThanOrEqual => " >= ",
            ExpressionType.LessThan => " < ",
            ExpressionType.LessThanOrEqual => " <= ",
            ExpressionType.NotEqual => " <> ",
            _ => throw new NotSupportedException("Operator not supported")
        });

        Visit(node.Right);
        _sql.Append(")");

        return node;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        _sql.Append(node.Member.Name.ToLower());
        return node;
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        _sql.Append(node.Value?.ToString());
        return node;
    }
}
