using Breadboard.Application.Authentication;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.Users.Commands;
using Breadboard.Application.Users.Repositories;
using Breadboard.Domain.Users.Viewmodels;
using Mediator;

namespace Breadboard.Application.Users.Handlers;

public class LoginHandler(
    IUserRepository _rep,
    IJwtAuthService _authentication,
    IPasswordHasher _passwordHasher
)
    : ICommandHandler<LoginCommand, Result<LoginViewmodel>>
{

    public async ValueTask<Result<LoginViewmodel>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //todo: solve this after implementing authorization
        var user = await _rep.GetByUsername(request.Username);

        if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
            return Results.Unauthorized<LoginViewmodel>();

        var token = _authentication.GenerateToken(user);

        return Results.Ok(new LoginViewmodel(token))!;
    }
}