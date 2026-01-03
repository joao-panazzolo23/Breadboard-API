using System.Linq.Expressions;
using Mediator;

namespace Breadboard.Application.Helpers;

public static class ValidationHelpers
{
    public static List<Expression<Func<T, string>>> Fields<T>(params Expression<Func<T, string>>[] fields)
    {
        return [..fields];
    }
}