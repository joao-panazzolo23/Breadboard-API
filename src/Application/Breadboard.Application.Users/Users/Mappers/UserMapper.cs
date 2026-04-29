using Riok.Mapperly.Abstractions;

namespace Users.Application.Users.Mappers;

[Mapper]
public static partial class UserMapper
{
    // [MapperIgnoreTarget(nameof(Entity.Id))]
    // [MapperIgnoreTarget(nameof(Entity.CreatedAt))]
    // [MapperIgnoreTarget(nameof(Entity.UpdatedAt))]
    // [MapperIgnoreSource(nameof(RegisterUserCommand.ConfirmPassword))]
    // public static partial User Map( this RegisterUserCommand command);

}