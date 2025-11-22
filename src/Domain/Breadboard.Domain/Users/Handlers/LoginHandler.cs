using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Entities;
using Breadboard.Shared.Factories;

namespace Breadboard.Domain.Users.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, LoginViewmodel?>
{
    public async Task<Result<LoginViewmodel?>> Handle(LoginCommand request)
    {
        await Task.CompletedTask;
        return Resulter.Success<LoginViewmodel>(new LoginViewmodel());
    }
}