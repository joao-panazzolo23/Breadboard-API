using Microsoft.Extensions.Hosting;

namespace BuildingBlocks.Mqtt.Workers;

/// <summary>
/// Responsibility: Connect broker at startup,
/// subscribe to topics,
/// receive messages, dispatch to handler
/// </summary>
public class MqttBackgroundWorker : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}