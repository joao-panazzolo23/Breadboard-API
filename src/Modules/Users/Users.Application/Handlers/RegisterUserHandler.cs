using Breadboard.Application.Authentication;
using Breadboard.Application.Data;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.ResultPattern.Factory;
using Breadboard.Domain.Entities;
using Breadboard.Domain.Repositories;
using Mediator;
using Users.Application.Commands;
using Unit = Mediator.Unit;

namespace Users.Application.Handlers;

public class RegisterUserHandler(
    IUserRepository _repository,
    //todo: UnityOfWork is not viable here
    IUnityOfWork _unity,
    IPasswordHasher _hasher
)
    : ICommandHandler<RegisterUserCommand, Result<Unit>>
{
    public async ValueTask<Result<Unit>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken
    )
    {
        if (await _repository.GetByUsername(request.Username) != null)
            return ResultFactory<Unit>.Conflict(message: "The informed username is already taken.");

        var user = new User(
            request.Username,
            _hasher.Hash(request.Password),
            request.Email,
            request.BirthDate,
            request.ExhibitionName);

        await _repository.Create(user);

        await _unity.Commit();

        return ResultFactory<Unit>.Ok();
    }
}