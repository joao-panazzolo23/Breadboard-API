using Breadboard.Application.Cops;
using Breadboard.Application.Data;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.ResultPattern.Factory;
using Breadboard.Domain.Repositories;
using Mediator;
using Users.Application.Commands;

namespace Users.Application.Handlers;

public class DeleteUserHandler(
    IUserRepository _repository,
    IUnityOfWork _unity)
    : IRequestHandler<DeleteUserCommand, Result<Unit>>
{

    public async ValueTask<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.Id);

        if (user == null) return ResultFactory<Unit>.NotFound();

        _repository.Delete(user);

        await _unity.Commit();

        return ResultFactory<Unit>.Ok();
    }
}