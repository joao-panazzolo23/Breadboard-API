namespace Breadboard.Application.Cops.Models;

public record HandlerTypeInfo(
    Type HandlerType,
    Type RequestType,
    //Type InterfaceType,
    Type ResponseType
);