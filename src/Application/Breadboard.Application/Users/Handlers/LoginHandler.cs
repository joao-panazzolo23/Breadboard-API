using Breadboard.Domain.Authentication;
using Breadboard.Domain.Services;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Repositories;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Results;

namespace Breadboard.Domain.Users.Handlers;

public class LoginHandler(
    IUserRepository _rep,
    IJwtAuthService _authentication,
    IPasswordHasher _passwordHasher
)
    : IRequestHandler<LoginCommand, LoginViewmodel>
{
    /// <summary>
    /// Unnecessary to differentiate not found from wrong password, it is a security flaw. 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<Result<LoginViewmodel>> Handle(LoginCommand request)
    {
        //todo: solve this after implementing authorization
        var user = await _rep.GetByUsername(request.Username);

        if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
            return Results.Unauthorized<LoginViewmodel>();

        var token = _authentication.GenerateToken(user);

        return Results.Ok(new LoginViewmodel(token))!;
    }
}