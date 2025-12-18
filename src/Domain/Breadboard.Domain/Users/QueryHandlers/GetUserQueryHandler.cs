using Breadboard.Domain.Users.Commands;
using Breadboard.Domain.Users.Queries;
using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Shared.Cops;
using Breadboard.Shared.Entities;
using Breadboard.Shared.Factories;

namespace Breadboard.Domain.Users.QueryHandlers;

public class GetUserQueryHandler(IUserQueryRepository repo) : IRequestHandler<GetUserQueryCommand, UserViewmodel?>
{
    private readonly IUserQueryRepository _repo = repo;

    public async Task<TypedResult<UserViewmodel?>> Handle(GetUserQueryCommand request)
    {
        var user = await _repo.GetById(request.Id);
        return user is null ? Result.NotFound<UserViewmodel?>() : Result.Success(user);
    }
}