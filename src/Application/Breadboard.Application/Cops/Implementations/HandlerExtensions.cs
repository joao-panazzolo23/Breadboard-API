using System.Reflection;
using Breadboard.Application.Cops.Abstractions;
using Breadboard.Application.CopsConcrete.Models;

namespace Breadboard.Application.Cops.Implementations;

public static class HandlerExtensions
{
    public static IEnumerable<HandlerTypeInfo> DiscoverHandlers(this Assembly assembly)
    {
        return assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .SelectMany(t => t.GetInterfaces()
                .Where(i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                .Select(i =>
                {
                    var args = i.GetGenericArguments();
                    return new HandlerTypeInfo(
                        HandlerType: t,
                        //InterfaceType: i,
                        RequestType: args[0], // TRequest
                        ResponseType: args[1] // TResponse
                    );
                })
            );
    }
}