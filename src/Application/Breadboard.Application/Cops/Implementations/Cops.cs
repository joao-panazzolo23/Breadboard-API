using Breadboard.Application.Cops;
using Breadboard.Application.CopsConcrete.Models;
using Breadboard.Application.ResultPattern;

namespace Breadboard.Application.CopsConcrete;

public class Cops(Dictionary<Type, HandlerRegistration> handlers) : ICops
{
    public async Task<Result<TResponse>> Dispatch<TResponse>(object request)
    {
        var requestType = request.GetType();
        if (!handlers.TryGetValue(requestType, out var handler))
            throw new InvalidOperationException($"No handler found for {requestType.Name}");

        var result = await handler.HandleAsync(request);

        return (Result<TResponse>)result;
    }
}