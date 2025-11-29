using System.Text.RegularExpressions;

namespace Breadboard.Application.TransformCase;

public class KebabCaseUrlTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null) return null;

        var input = value.ToString();

        if (string.IsNullOrEmpty(input))
            return null;
        

        return Regex.Replace(input, "([a-z])([A-Z])", "$1-$2").ToLowerInvariant();
    }
}