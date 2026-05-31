namespace Mqtt.Domain.Abstract;

public interface IMqttPublisher
{
    Task PublishAsync(string topic, string payload, CancellationToken ct);
}