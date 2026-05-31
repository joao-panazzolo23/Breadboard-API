namespace Mqtt.Domain.Abstract;

public interface IMqttMessageHandler
{
    string Topic { get; }
    Task HandleAsync(string payload, CancellationToken ct);
}