using System.Reflection;
using Breadboard.Shared.Entities;
using Breadboard.Shared.LightBridge;

namespace Breadboard.Infra.LightBridget.Extensions;

public static class HandlerExtensions
{
    public static IEnumerable<HandlerTypeInfo> DiscoverHandlers(this Assembly assembly)
    {
        return assembly.GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false })
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .Select(i =>
                {
                    var args = i.GetGenericArguments();
                    return new HandlerTypeInfo(
                        HandlerType: t,
                        InterfaceType: i,
                        RequestType: args[0], // TRequest
                        ResponseType: args[1] // TResponse
                    );
                })
            );

    }
}