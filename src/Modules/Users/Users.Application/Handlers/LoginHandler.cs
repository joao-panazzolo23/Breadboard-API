using Breadboard.Application.Authentication;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.ResultPattern.Factory;
using Breadboard.Domain.DTOs;
using Breadboard.Domain.Repositories;
using Mediator;
using Users.Application.Commands;

namespace Users.Application.Handlers;

public class LoginHandler(
    IUserRepository _rep,
    ITokenService _authentication,
    IPasswordHasher _passwordHasher
)
    : ICommandHandler<LoginCommand, Result<LoginDto?>>
{
    public async ValueTask<Result<LoginDto?>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //todo: solve this after implementing authorization
        var user = await _rep.GetByUsername(request.Username);

        if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
            return ResultFactory<LoginDto>.Unauthorized();


        var token = _authentication.Generate(user);

        return ResultFactory<LoginDto>.Ok(new LoginDto(token))!;
    }
}