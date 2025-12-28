using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.Repositories;

namespace Breadboard.Infra.PostgreSQL.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User?> GetByUsername(string username)
    {
        throw new NotImplementedException();
    }
}