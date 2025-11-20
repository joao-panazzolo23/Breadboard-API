using Breadboard.Shared.Entities;

namespace Breadboard.Shared.LightBridge;

public interface ILightBridge
{
    Task<Result<TResponse>> Send<TResponse>(object request);
}