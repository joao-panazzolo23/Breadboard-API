using System.Text.RegularExpressions;

namespace Breadboard.Shared.Extensions;

public static class KebabCaseExtensions
{
    public static string ToKebabCase(this string value)
    {
        // converts PascalCase/CamelCase to kebab-case
        return Regex.Replace(value, "(?<!^)([A-Z])", "-$1").ToLower();
    }
}