using Breadboard.Domain;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Entities;
using Riok.Mapperly.Abstractions;

namespace Breadboard.Application.Users.Mappers;

[Mapper]
public static partial class UserMapper
{
    [MapperIgnoreTarget(nameof(Entity.Id))]
    [MapperIgnoreTarget(nameof(Entity.CreatedAt))]
    [MapperIgnoreTarget(nameof(Entity.UpdatedAt))]
    [MapperIgnoreSource(nameof(RegisterUserCommand.ConfirmPassword))]
    public static partial User Map(this RegisterUserCommand command);
}