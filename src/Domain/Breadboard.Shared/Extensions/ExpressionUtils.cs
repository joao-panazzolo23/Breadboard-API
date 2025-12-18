using System.Linq.Expressions;

namespace Breadboard.Shared.Extensions;

public static class ExpressionUtils
{
    /// <summary>
    /// todo: this function is not correctly being executed.
    /// It gets the property name but not the property itself
    /// </summary>
    /// <param name="exp"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string GetPropName<T>(Expression<Func<T, object>> exp)
    {
        return exp.Body switch
        {
            MemberExpression member => member.Member.Name,
            UnaryExpression { Operand: MemberExpression m } => m.Member.Name,
            _ => throw new InvalidOperationException("Invalid expression")
        };
    }
}