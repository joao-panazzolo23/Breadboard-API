using System.Text.RegularExpressions;

namespace Breadboard.Presentation.TransformCase;

public class KebabCaseUrlTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null) return null;

        var input = value.ToString();

        return string.IsNullOrEmpty(input) ? null : Regex.Replace(input, "([a-z])([A-Z])", "$1-$2").ToLowerInvariant();
    }
}