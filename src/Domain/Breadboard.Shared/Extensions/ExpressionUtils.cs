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
        if (exp.Body is MemberExpression member)
            return member.Member.Name;

        if (exp.Body is UnaryExpression u && u.Operand is MemberExpression m)
            return m.Member.Name;

        // if (exp.Body is NewExpression n)
        //     return n.Arguments
        //         .OfType<MemberExpression>()
        //         .Select(a => a.Member.Name)
        //         .ToList();

        throw new InvalidOperationException("Invalid expression");
    }
}