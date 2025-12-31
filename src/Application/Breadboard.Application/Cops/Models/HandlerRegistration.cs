namespace Breadboard.Application.CopsConcrete.Models;

public record HandlerRegistration(
    Func<object, Task<object>> HandleAsync
);

// usability for that?
// Type InterfaceType,
// Type ResponseType