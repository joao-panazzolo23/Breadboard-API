using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DynamicVersionAttribute : Attribute
{
    public ApiVersion Version { get; }

    public DynamicVersionAttribute()
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        Version = new ApiVersion(version?.Major ?? 1, version?.Minor ?? 0);
    }
}