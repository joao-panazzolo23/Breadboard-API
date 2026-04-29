using Microsoft.AspNetCore.Mvc;

namespace SharedKernel.Presentation.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AutoRoutingAttribute(string apiVersion = "1") : RouteAttribute($"api/v{apiVersion}/[controller]");