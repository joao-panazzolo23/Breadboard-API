using Breadboard.Shared.LightBridge;
namespace Breadboard.Infra.LightBridget.LightBridge;

public class LightBridge(Dictionary<Type, object> handlers) : ILightBridge
{
    public async Task<TResponse> Send<TResponse>(object request)
    {
        var requestType = request.GetType();
        if (!handlers.TryGetValue(requestType, out var handlerObj))
            throw new InvalidOperationException($"No handler found for {requestType.Name}");

        var method = handlerObj.GetType().GetMethod("Handle");
        return await (Task<TResponse>)method!.Invoke(handlerObj, [request])!;
    }
}