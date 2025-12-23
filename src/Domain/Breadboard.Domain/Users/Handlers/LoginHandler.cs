using Breadboard.Domain.Services;
using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Results;

namespace Breadboard.Domain.Users.Handlers;

public class LoginHandler(IUserQueryRepository rep, IJwtAuthService authentication)
    : IRequestHandler<LoginCommand, LoginViewmodel>
{
    public async Task<Result<LoginViewmodel>> Handle(LoginCommand request)
    {
        //todo: solve this after implementing authorization
        // var user = await rep.GetByUserName(request.Username);
        //
        // if (user == null)
        //     return Results.NotFound<LoginViewmodel>();   
        //
        // // if (!await authentication.Validate(request.Token))
        // //     return Results.Unauthorized<LoginViewmodel>();
        // //
        // // var login = new LoginViewmodel(await authentication.GenerateToken(user.Username, 
        // //                                                                    user.Password, 
        // //
        // // user.Email));
        // return Results.Success()!;

        throw new NotImplementedException();
    }
}