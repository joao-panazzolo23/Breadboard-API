namespace Breadboard.Shared.Entities;

public record HandlerTypeInfo(
    Type HandlerType, 
    Type RequestType,
    //Type InterfaceType,
    Type ResponseType
    );