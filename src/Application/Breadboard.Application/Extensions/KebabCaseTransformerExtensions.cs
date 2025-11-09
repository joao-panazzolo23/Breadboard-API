using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Breadboard.Application.Extensions
{
  public class KebabCaseParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value == null) return null;

        var input = value.ToString();

        if (string.IsNullOrEmpty(input))
            return null;
        
        //dotnet already does that
        // if (input.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
        //     input = input[..^"Controller".Length];
        
        return Regex.Replace(input, "([a-z])([A-Z])", "$1-$2").ToLowerInvariant();
    }
}
}