namespace Breadboard.Shared.Exceptions;

public class DomainException(string error) : Exception
{
    public string Error { get; init; } = error;
}