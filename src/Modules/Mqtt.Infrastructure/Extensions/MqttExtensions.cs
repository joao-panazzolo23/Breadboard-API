using BuildingBlocks.Mqtt.Workers;
using Microsoft.Extensions.DependencyInjection;
using Mqtt.Domain.Abstract;
using MQTTnet;

namespace Mqtt.Infrastructure.Extensions;

/// <summary>
/// MQTT (Message Queuing Telemetry Transport) is not even close to HTTP.
/// It is a message broker.
/// It doesn't have Requests and direct answers from the server,
/// it has publishers, brokers and subscribers.
///
/// Publishers =>  Who sends the information in a topic.
/// Broker => Mains service that receives and delivers the topics.
/// Subscribers =>  
///
/// It don't have methods as HTTP does, it has TOPICS (Hierarchical Strings)
/// and QoS. QoS means Quality of Service, and it is separated between:
/// qos0 -> Fire and forget, may cause data loss.
/// qos1 -> Delivers at least once, may cause duplicates.
/// qos2 -> Just once, nothing more.
///
/// Retained Messages => When published using retained = true, broker
/// holds the last topic message and delivers and delivers immediately
/// to any new subscribers, useful to actual device's state. 
/// Topic Nomenclature stands just like HTTP Url's:
/// {domain}/{type}/{device-id}/{data}
/// always lower case, including device Identifier to filter
///
/// Wildcards:
///  + (Plus) means one level up.
///  # (Hashtag) means all levels 
///
/// Payload: structured JSON. Don't trust topic's time of arrival,
/// it often does not mean the real time. The real solution is using
/// timestamp within the payload JSON.
///
/// Security: use TLS with 8883 port.
/// You can authenticate every device with
/// ClientId + User/Password + mTLS certificate
///
/// See more about this implementation:
/// https://dotnet.github.io/MQTTnet/
/// </summary>
public static class MqttExtensions
{
    public static IServiceCollection AddMqttDependencies(this IServiceCollection services)
    {
        services.AddSingleton<MqttClientFactory>();

        services.AddSingleton<IMqttClient>(_ =>
            new MqttClientFactory().CreateMqttClient()
        );
        
        var handlers = typeof(MqttExtensions).Assembly
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract
                                  && t.IsAssignableTo(typeof(IMqttMessageHandler)));

        return services.AddHostedService<MqttBackgroundWorker>();
    }
}