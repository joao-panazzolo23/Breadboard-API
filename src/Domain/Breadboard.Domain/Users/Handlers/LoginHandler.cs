using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Entities;
using Breadboard.Shared.Factories;

namespace Breadboard.Domain.Users.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, LoginViewmodel?>
{
    private readonly IUserQueryRepository _rep;

    public LoginHandler(IUserQueryRepository rep)
    {
        _rep = rep;
    }

    public async Task<Result<LoginViewmodel?>> Handle(LoginCommand request)
    {
        var response = await _rep.GetById(Guid.Empty);
        await Task.CompletedTask;
        return Resulter.Success<LoginViewmodel>(new LoginViewmodel());
    }
}