namespace Breadboard.Shared.LightBridge;

public interface ILightBridge
{
    Task<TResponse> Send<TResponse>(object request);
}