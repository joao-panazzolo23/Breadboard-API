using Breadboard.Application.Cops.Abstractions;
using Breadboard.Application.ResultPattern;
using Breadboard.Application.ResultPattern.Factory;
using Breadboard.Domain.Users.DTOs;
using Breadboard.Domain.Users.QueryRepositories;
using Users.Application.Users.Queries;

namespace Users.Application.Users.QueryHandlers;

public class GetUserQueryHandler(IUserQueryRepository _repo) : IRequestHandler<GetUserQueryCommand, UserDto?>
{
    public async Task<Result<UserDto?>> Handle(GetUserQueryCommand request)
    {
        var user = await _repo.GetById(request.Id);

        return user is null ? ResultFactory<UserDto?>.NotFound() : ResultFactory<UserDto?>.Ok(user);
    }
}