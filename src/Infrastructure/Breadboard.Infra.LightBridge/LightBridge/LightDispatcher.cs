using Breadboard.Shared.Entities;
using Breadboard.Shared.LightBridge;

namespace Breadboard.Infra.LightBridget.LightBridge;

public class LightDispatcher(Dictionary<Type, HandlerRegistration> handlers) : ILightDispatcher
{
    public async Task<Result<TResponse>> Dispatch<TResponse>(object request)
    {
        var requestType = request.GetType();
        if (!handlers.TryGetValue(requestType, out var handler))
            throw new InvalidOperationException($"No handler found for {requestType.Name}");

        var result = await handler.HandleAsync(request);
        // var method = handlerObj.Instance.GetType().GetMethod("Handle");
        // return await (Task<Result<TResponse>>)method!.Invoke(handlerObj.Instance, [request])!;
        return (Result<TResponse>)result;
    }
}