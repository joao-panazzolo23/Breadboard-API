using System.Reflection;
using Breadboard.Infra.LightBridget.Extensions;
using Breadboard.Infra.LightBridget.LightBridge;
using Breadboard.Shared.Entities;
using Breadboard.Shared.LightBridge;
using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Infra.LightBridge.Extensions;

public static class LightBridgeExtensions
{
    public static IServiceCollection AddLightBridge(
        this IServiceCollection services, Assembly assembly)
    {
        foreach (var ht in assembly.DiscoverHandlers())
            services.AddTransient(ht.HandlerType);

        services.AddSingleton<ILightDispatcher>(sp =>
        {
            var handlers = new Dictionary<Type, HandlerRegistration>();

            foreach (var h in assembly.DiscoverHandlers())
            {
                // Gera delegate fortemente tipado
                var dispatcher =
                    InvokerLight.CreateInvoker(h.RequestType,
                        h.ResponseType,
                        sp.GetRequiredService(h.HandlerType));

                handlers[h.RequestType] = new HandlerRegistration(dispatcher);
            }

            return new LightDispatcher(handlers);
        });

        return services;
    }
}
//old method, using reflections when calling "Send" method. Not viable due to performance issues
//     public static IServiceCollection AddLightBridge(
//         this IServiceCollection services, Assembly assembly)
//     {
//         foreach (var ht in assembly.DiscoverHandlers())
//         {
//             services.AddTransient(ht.HandlerType);
//         }
//
//         services.AddSingleton<ILightDispatcher>(sp =>
//         {
//             var handlers = assembly.DiscoverHandlers()
//                 .ToDictionary(
//                     h => h.RequestType,
//                     h =>
//                     {
//                         var instance = sp.GetRequiredService(h.HandlerType)!;
//                         var method = h.InterfaceType.GetMethod("Handle")!;
//
//                         Func<object, Task<object>> handleAsync = async (request) =>
//                         {
//                             var task = (Task)method.Invoke(instance, new object[] { request })!;
//                             await task;
//
//                             // get handler's result 
//                             var resultProperty = task.GetType().GetProperty("Result")!;
//                             return resultProperty.GetValue(task)!;
//                         };
//
//                         return new HandlerRegistration(
//                             HandleAsync: handleAsync
//                         );
//                     }
//
//                     // new HandlerRegistration(
//                     // Instance: sp.GetRequiredService(h.HandlerType)!,
//                     // InterfaceType: h.InterfaceType,
//                     // ResponseType: h.ResponseType)
//                 );
//
//             return new LightDispatcher(handlers);
//         });
//         return services;
//     }
// }

//even older method, even worst strategy
// services.AddSingleton<ILightBridge>(sp =>
// {
//     var handlers = assembly.DiscoverHandlers()
//         .ToDictionary(
//             h => h.RequestType,
//             h => new HandlerRegistration(
//                 Instance: sp.GetRequiredService(h.HandlerType)!,
//                 InterfaceType: h.InterfaceType,
//                 ResponseType: h.ResponseType
//             )
//         );
//
//     return new LightBridge.LightBridge(handlers);
// });