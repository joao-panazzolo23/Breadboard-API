using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Entities;
using Breadboard.Shared.LightBridge;

namespace Breadboard.Domain.Users.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, LoginViewmodel>
{
    public Task<Result<LoginViewmodel>> Handle(LoginCommand request)
    {
        throw new NotImplementedException();
    }
}