using System.Linq.Expressions;
using System.Reflection;
using Breadboard.Domain.Users.DTOs;
using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Infra.PostgreSQLDapper.Abstractions;
using Breadboard.Infra.PostgreSQLDapper.Context;
using Breadboard.Infra.PostgreSQLDapper.QueryBuilder;
using Dapper;

namespace Breadboard.Infra.PostgreSQLDapper.QueryRepositories.Users;

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