using Breadboard.Application.Cops;
using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Repositories;
using Breadboard.Shared.Repository;

namespace Breadboard.Application.Users.Handlers;

public class DeleteUserHandler(
    IUserRepository _repository,
    IUnityOfWork _unity)
    : IRequestHandler<DeleteUserCommand, Nothing>
{
    public async Task<Result<Nothing>> Handle(DeleteUserCommand request)
    {
        var user = await _repository.GetById(request.Id);

        if (user == null) return Results.NotFound<Nothing>();

        _repository.Delete(user);

        await _unity.Commit();

        return Results.Ok(Nothing.Value);
    }
}