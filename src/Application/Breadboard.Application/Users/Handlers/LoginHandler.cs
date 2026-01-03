using Breadboard.Application.Authentication;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.Users.Commands;
using Breadboard.Application.Users.Repositories;
using Breadboard.Domain.Users.DTOs;
using Mediator;

namespace Breadboard.Application.Users.Handlers;

public class LoginHandler(
    IUserRepository _rep,
    IJwtAuthService _authentication,
    IPasswordHasher _passwordHasher
)
    : ICommandHandler<LoginCommand, Result<LoginDto?>>
{
    public async ValueTask<Result<LoginDto?>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //todo: solve this after implementing authorization
        var user = await _rep.GetByUsername(request.Username);

        if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
            return Results.Unauthorized<LoginDto>();


        var token = _authentication.GenerateToken(user);

        return Results.Ok(new LoginDto(token))!;
    }
}