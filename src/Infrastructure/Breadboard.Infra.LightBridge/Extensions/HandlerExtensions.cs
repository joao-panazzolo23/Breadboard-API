using System.Reflection;
using Breadboard.Shared.Entities;
using Breadboard.Shared.LightBridge;

namespace Breadboard.Infra.LightBridget.Extensions;

public static class HandlerExtensions
{
    public static IEnumerable<HandlerTypeInfo> DiscoverHandlers(this Assembly assembly)
    {
        return assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .Select(i => new HandlerTypeInfo(
                    HandlerType: t,
                    RequestType: i.GetGenericArguments()[0] // TRequest
                ))
            );

    }
}