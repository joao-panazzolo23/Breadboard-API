using Breadboard.Domain.Users.QueryRepositories;
using Breadboard.Infra.PostgreSQLDapper.Context;
using Breadboard.Shared.Repository;
using Dapper;

namespace Breadboard.Infra.PostgreSQLDapper.QueryRepositories.Users;

public class UserQueryRepository(PostgreSqlContext context) : IQueryRepository, IUserQueryRepository
{
    public Task<dynamic?> GetById(Guid id)
    {
        var sql = $@"select * from ""Users"" where id = @id";

        return context.Connection.QueryFirstOrDefaultAsync<dynamic>(sql, new { id });
    }

    public Task<dynamic> List()
    {
        throw new NotImplementedException();
    }
}