using Breadboard.Domain.DTOs;
using Breadboard.Domain.Entities;
using Breadboard.Domain.QueryRepositories;
using BuildingBlocks.PostgreSQLDapper.Context;
using BuildingBlocks.PostgreSQLDapper.QueryBuilder;
using Dapper;

namespace BuildingBlocks.PostgreSQLDapper.QueryRepositories.Users;

public class UserQueryRepository(
    PostgreSqlContext context
    ) : IUserQueryRepository
{
    public Task<UserDto?> GetById(Guid id)
    {
        var sql = Query.From<User>()
            .Select(u => u.Id)
            .Where(u => u.Id == id)
            .Build();

        return context.Connection.QueryFirstOrDefaultAsync<UserDto>(sql, new {id});
    }

    public Task<UserDto?> GetByUserName(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> List()
    {
        throw new NotImplementedException();
    }

   
}