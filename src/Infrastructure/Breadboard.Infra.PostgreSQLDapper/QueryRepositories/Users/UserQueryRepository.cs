using System.Linq.Expressions;
using System.Reflection;
using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Domain.Users.Viewmodels;
using Breadboard.Infra.PostgreSQLDapper.Abstractions;
using Breadboard.Infra.PostgreSQLDapper.Context;
using Breadboard.Infra.PostgreSQLDapper.QueryBuilder;
using Dapper;

namespace Breadboard.Infra.PostgreSQLDapper.QueryRepositories.Users;

public class UserQueryRepository(PostgreSqlContext context) : IQueryRepository, IUserQueryRepository
{
    public Task<UserViewmodel?> GetById(Guid id)
    {
        var sql = Query.From<User>()
            .Select(u => u.Id)
            .Where(u => u.Id == id)
            .Build();

        return context.Connection.QueryFirstOrDefaultAsync<UserViewmodel>(sql, new {id});
    }

    public Task<UserViewmodel?> GetByUserName(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserViewmodel>> List()
    {
        throw new NotImplementedException();
    }

   
}