using Microsoft.Extensions.DependencyInjection;

namespace Breadboard.Infra.LightBridget.Factories;

public static class HandlerFactory
{
    public static object CreateInstance(IServiceProvider sp, Type handlerType)
    {
        return sp.GetRequiredService(handlerType);
    }
}