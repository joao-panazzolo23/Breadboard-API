using Breadboard.Application.Cops;
using Breadboard.Application.Cops.Abstractions;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.Users.Commands;
using Breadboard.Application.Users.Mappers;
using Breadboard.Application.Users.Repositories;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Entities;

namespace Breadboard.Application.Users.Handlers;

public class RegisterUserHandler(IUserRepository _repository, IUnityOfWork _unity)
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