using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.Queries;
using Breadboard.Shared.Entities;
using Riok.Mapperly.Abstractions;

namespace Breadboard.Domain.Users.Mappers;

[Mapper]
public static partial class UserMapper
{
    [MapperIgnoreTarget(nameof(Entity.Id))]
    [MapperIgnoreTarget(nameof(Entity.CreatedAt))]
    [MapperIgnoreTarget(nameof(Entity.UpdatedAt))]
    public static partial User Map(this RegisterUserCommand command);
}