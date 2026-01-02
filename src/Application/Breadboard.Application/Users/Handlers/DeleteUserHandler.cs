using Breadboard.Application.Cops;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.Users.Commands;
using Breadboard.Application.Users.Repositories;
using Mediator;

namespace Breadboard.Application.Users.Handlers;

public class DeleteUserHandler(
    IUserRepository _repository,
    IUnityOfWork _unity)
    : IRequestHandler<DeleteUserCommand, Result<Unit>>
{

    public async ValueTask<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.Id);

        if (user == null) return Results.NotFound<Unit>();

        _repository.Delete(user);

        await _unity.Commit();

        return Results.Ok<Unit>();
    }
}