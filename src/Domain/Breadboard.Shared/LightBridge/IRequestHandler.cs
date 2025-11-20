using Breadboard.Shared.Entities;

namespace Breadboard.Shared.LightBridge;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<Result<TResponse>> Handle(TRequest request);
}