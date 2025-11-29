using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AutoRoutingAttribute(string template = "api/v{version:apiVersion}/[controller]")
    : RouteAttribute(template);