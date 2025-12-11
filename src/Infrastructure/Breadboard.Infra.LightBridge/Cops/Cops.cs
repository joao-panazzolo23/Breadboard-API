using Breadboard.Shared.Cops;
using Breadboard.Shared.Entities;

namespace Breadboard.Infra.COPS.Cops;

public class Cops(Dictionary<Type, HandlerRegistration> handlers) : ICops
{
    public async Task<TypedResult<TResponse>> Dispatch<TResponse>(object request)
    {
        var requestType = request.GetType();
        if (!handlers.TryGetValue(requestType, out var handler))
            throw new InvalidOperationException($"No handler found for {requestType.Name}");

        var result = await handler.HandleAsync(request);
        // var method = handlerObj.Instance.GetType().GetMethod("Handle");
        // return await (Task<Result<TResponse>>)method!.Invoke(handlerObj.Instance, [request])!;
        return (TypedResult<TResponse>)result;
    }
}