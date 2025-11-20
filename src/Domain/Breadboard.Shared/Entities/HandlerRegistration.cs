namespace Breadboard.Shared.Entities;

public record HandlerRegistration(
    object Instance,
    Type InterfaceType,
    Type ResponseType
);
