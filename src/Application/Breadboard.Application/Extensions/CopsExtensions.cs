using System.Reflection;
using Breadboard.Application.Cops;
using Breadboard.Application.Cops.Implementations;
using Breadboard.Application.CopsConcrete;
using Breadboard.Application.CopsConcrete.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Application.Extensions;

public static class CopsExtensions
{
    public static IServiceCollection AddCops(
        this IServiceCollection services, Assembly assembly)
    {
        foreach (var ht in assembly.DiscoverHandlers())
            services.AddTransient(ht.HandlerType);

        services.AddScoped<ICops>(sp =>
        {
            var handlers = new Dictionary<Type, HandlerRegistration>();

            foreach (var h in assembly.DiscoverHandlers())
            {
                // generates heavily typed delegate
                var dispatcher =
                    InvokeCops.CreateInvoker(h.RequestType,
                        h.ResponseType,
                        sp.GetRequiredService(h.HandlerType));

                handlers[h.RequestType] = new HandlerRegistration(dispatcher);
            }

            return new CopsConcrete.Cops(handlers);
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