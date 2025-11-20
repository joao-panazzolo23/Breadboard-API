using Breadboard.Shared.Entities;
using Breadboard.Shared.LightBridge;

namespace Breadboard.Infra.LightBridget.LightBridge;

public class LightBridge(Dictionary<Type, HandlerRegistration> handlers) : ILightBridge
{
    public async Task<Result<TResponse>> Send<TResponse>(object request)
    {
        var requestType = request.GetType();
        if (!handlers.TryGetValue(requestType, out var handlerObj))
            throw new InvalidOperationException($"No handler found for {requestType.Name}");

        var method = handlerObj.Instance.GetType().GetMethod("Handle");
        return await (Task<Result<TResponse>>)method!.Invoke(handlerObj.Instance, [request])!;
    }
}