using Mediator;

namespace Mqtt.Application.Dto;

public record SensorDataReceived(string Payload) : INotification;