using System.Linq.Expressions;
using System.Reflection;
using Breadboard.Domain.Users.DTOs;
using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.QueryRepositories;
using BuildingBlocks.PostgreSQLDapper.Abstractions;
using BuildingBlocks.PostgreSQLDapper.Context;
using BuildingBlocks.PostgreSQLDapper.QueryBuilder;
using Dapper;

namespace BuildingBlocks.PostgreSQLDapper.QueryRepositories.Users;

public class UserQueryRepository(PostgreSqlContext context) : IQueryRepository, IUserQueryRepository
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