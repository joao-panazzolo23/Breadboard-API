namespace Breadboard.Domain.Exceptions;

public class DomainException(string error) : Exception
{
    public string Error { get; init; } = error;
}