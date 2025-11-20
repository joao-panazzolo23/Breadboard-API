using Breadboard.Shared.Entities;

namespace Breadboard.Shared.LightBridge;

public interface ILightDispatcher
{
    Task<Result<TResponse>> Dispatch<TResponse>(object request);
}