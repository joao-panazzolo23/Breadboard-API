namespace BuildingBlocks.Mqtt.Options;

/// <summary>
/// Todo: register and set within appsettings.json
/// </summary>
public class MqttOptions
{
    public string Host { get; init; } = "";
    public int Port { get; init; } = 1883;
    public string ClientId { get; init; } = "";
    public string Username { get; init; } = "";
    public string Password { get; init; } = "";
}