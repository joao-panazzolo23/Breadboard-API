using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.Mappers;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Repository;
using Breadboard.Shared.Results;

namespace Breadboard.Domain.Users.Handlers;

public class RegisterUserHandler(IGenericRepository<User> _repository, IUnityOfWork _unity)
    : IRequestHandler<RegisterUserCommand, Nothing>
{
    public async Task<Result<Nothing>> Handle(RegisterUserCommand request)
    {
        var user = request.Map();

        await _repository.Create(user);

        await _unity.Commit();
        return Results.Ok<Nothing>();
    }
}