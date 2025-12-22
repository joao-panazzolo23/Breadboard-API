using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Entities;
using Breadboard.Shared.Results;

namespace Breadboard.Domain.Users.Handlers;

public class LoginHandler(IUserQueryRepository rep) : IRequestHandler<LoginCommand, LoginViewmodel?>
{
    private readonly IUserQueryRepository _rep = rep;

    public Task<Result<LoginViewmodel?>> Handle(LoginCommand request)
    {
        throw new NotImplementedException();
    }
}