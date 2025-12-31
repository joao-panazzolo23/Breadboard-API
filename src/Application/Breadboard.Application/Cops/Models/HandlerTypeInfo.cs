namespace Breadboard.Application.CopsConcrete.Models;

public record HandlerTypeInfo(
    Type HandlerType,
    Type RequestType,
    //Type InterfaceType,
    Type ResponseType
);