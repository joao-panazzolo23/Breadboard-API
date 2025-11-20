using System.Reflection;
using Breadboard.Shared.Entities;
using Breadboard.Shared.LightBridge;
using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Infra.LightBridget.Extensions;

public static class LightBridgeExtensions
{
    public static IServiceCollection AddLightBridge(
        this IServiceCollection services, Assembly assembly)
    {
        foreach (var ht in assembly.DiscoverHandlers())
        {
            services.AddTransient(ht.HandlerType);
        }

        services.AddSingleton<ILightBridge>(sp =>
        {
            var handlers = assembly.DiscoverHandlers()
                .ToDictionary(
                    h => h.RequestType,
                    h => new HandlerRegistration(
                        Instance: sp.GetRequiredService(h.HandlerType)!,
                        InterfaceType: h.InterfaceType,
                        ResponseType: h.ResponseType
                    )
                );

            return new LightBridge.LightBridge(handlers);
        });


        return services;
    }
}