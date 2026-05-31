using BuildingBlocks.Mqtt.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mqtt.Domain.Abstract;
using MQTTnet;

namespace Finances.Infrastructure.Workers
{
    public class MqttBackgroundWorker(
        IMqttClient client,
        IEnumerable<IMqttMessageHandler> handlers,
        MqttOptions options,
        ILogger<MqttBackgroundWorker> logger)
        : BackgroundService
    {
        private readonly ILogger<MqttBackgroundWorker> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            var options1 = new MqttClientOptionsBuilder()
                .WithTcpServer(options.Host, options.Port)
                .WithClientId(options.ClientId)
                .Build();

            client.ApplicationMessageReceivedAsync += async e =>
            {
                var topic = e.ApplicationMessage.Topic;
                var payload = e.ApplicationMessage.ConvertPayloadToString();

                var handler = handlers.FirstOrDefault(h => h.Topic == topic);
                if (handler is not null)
                    await handler.HandleAsync(payload, ct);
            };

            await client.ConnectAsync(options1, ct);

            foreach (var handler in handlers)
            {
                await client.SubscribeAsync(
                    new MqttTopicFilterBuilder()
                        .WithTopic(handler.Topic)
                        .Build(), ct);
            }

            await Task.Delay(Timeout.Infinite, ct);
        }
    }
}