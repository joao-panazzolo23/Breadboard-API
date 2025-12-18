using System.Linq.Expressions;
using System.Reflection;
using Dapper;

namespace Breadboard.Infra.PostgreSQLDapper.QueryBuilder;

/// <summary>
/// Todo:This is easy to implement but also not really good.
/// 1. It needs typing to understand parameters. Sometimes, I might not have an exact type.
/// 2. It needs to declare ONE BY ONE, by parameters to another function. Before, we used to declare all variables one by one
/// It doesn't even solve our problem and might as well create another one.
/// </summary>
internal static class ParamBuild
{
    /// <summary>
    /// When we are using variables/properties during runtime, C# does not keep track of its name
    /// but when we're using expressions, C# must hold its value since it needs to keep track of the expression rule
    ///
    /// And typing the expression is the way to know exacltly what to expect of them.
    /// It doesn't even need to have entities, they can be viedwmodels, commands, queries, etc. 
    /// </summary>
    /// <param name="paramArray"></param>
    /// <returns></returns>
    public static object BuildParameters<T>(
        params Expression<Func<T, bool>>[] predicates)
    {
        var parameters = new DynamicParameters();
        foreach (var predicate in predicates)
        {
            ParamBuild.ExtractParameters(predicate.Body, parameters);
        }

        return parameters;
    }

    private static void ExtractParameters(
        Expression expression,
        DynamicParameters parameters)
    {
        if (expression is not BinaryExpression
            {
                Left: MemberExpression { Expression: ParameterExpression } left
            } binary)
            throw new NotSupportedException(nameof(expression));

        var name = left.Member.Name;
        var value = GetValue(binary.Right);

        parameters.Add(name.ToLower(), value);
    }

    private static object? GetValue(Expression expression)
    {
        if (expression is ConstantExpression constant)
            return constant.Value;

        if (expression is not MemberExpression member)
            throw new NotSupportedException(nameof(expression));

        var obj = GetValue(member.Expression!);

        return member.Member switch
        {
            FieldInfo f => f.GetValue(obj),
            PropertyInfo p => p.GetValue(obj),
            _ => throw new NotSupportedException()
        };
    }
}