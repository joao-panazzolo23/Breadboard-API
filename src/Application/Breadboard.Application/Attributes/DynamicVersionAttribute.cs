using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Breadboard.Application.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
[Obsolete("This does not make any logical sense. I'm keeping it here as a matter of knowledge.")]
public class DynamicVersionAttribute : Attribute
{
    public ApiVersion Version { get; }

    /// <summary>
    /// Explaining why this does not make sense:
    /// If an API needs to be versioned, it means some part of it is receiving an update, nevertheless,
    /// almost in all situations, JUST ONE endpoint or ONE ENTIRE CONTROLLER is getting this update.
    /// Changing the entire API is almost ruining all previous consumptions without even redirecting through
    /// 301, 302, 307, 308 status code
    ///
    /// If you intend to use API Versioning, keep using AutoRouting Attribute, but instead of using DynamicVersion,
    /// explicit ApiVersion attribute to the requested version 
    /// </summary>
    [Obsolete("This does not make any logical sense.")]
    public DynamicVersionAttribute()
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        Version = new ApiVersion(version?.Major ?? 1, version?.Minor ?? 0);
    }
}