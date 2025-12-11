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
    public Task<UserViewmodel?> GetById(Guid Id)
    {
        var sql = Query.From<User>()
            .Select(u => u.Id)
            .Where(u => u.Id == Id)
            .Build();

        return context.Connection.QueryFirstOrDefaultAsync<UserViewmodel>(sql, new { Id });
    }

    public Task<IEnumerable<UserViewmodel>> List()
    {
        throw new NotImplementedException();
    }
}