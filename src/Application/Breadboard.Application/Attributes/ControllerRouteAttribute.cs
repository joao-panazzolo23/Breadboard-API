using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ControllerRouteAttribute : RouteAttribute
{
    public ControllerRouteAttribute(string template = "api/v{version:apiVersion}/[controller]") : base(template)
    {
        
    }
}