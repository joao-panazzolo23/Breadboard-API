using Breadboard.Application.Cops.Abstractions;
using Breadboard.Application.Cops.Models;
using Breadboard.Application.ResultPattern;

namespace Breadboard.Application.Cops.Implementations;

public class Cops(Dictionary<Type, HandlerRegistration> handlers) : ICops
{
    
    // IServiceProvider _serviceProvider
    public async Task<Result<TResponse>> Dispatch<TRequest,TResponse>(TRequest request)
    {
        var requestType = request.GetType();
        if (!handlers.TryGetValue(requestType, out var handler))
            throw new InvalidOperationException($"No handler found for {requestType.Name}");
        
        var result = await handler.HandleAsync(request);

        return (Result<TResponse>)result;
    }
}