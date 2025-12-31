using Breadboard.Application.Cops;
using Breadboard.Application.ResultPattern;
using Breadboard.Domain.Users.Queries;
using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Domain.Users.Viewmodels;

namespace Breadboard.Domain.Users.QueryHandlers;

public class GetUserQueryHandler(IUserQueryRepository _repo) : IRequestHandler<GetUserQueryCommand, UserViewmodel?>
{
    public async Task<Result<UserViewmodel?>> Handle(GetUserQueryCommand request)
    {
        var user = await _repo.GetById(request.Id);

        return user is null ? Results.NotFound<UserViewmodel?>() : Results.Ok(user);
    }
}