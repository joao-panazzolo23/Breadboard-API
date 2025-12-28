using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.Repositories;

namespace Breadboard.Infra.PostgreSQL.Repositories;

internal class UserRepository(AppDbContext context) : GenericRepository<User>(context), IUserRepository
{
    public Task<User?> GetByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public Task Delete(User user)
    {
        throw new NotImplementedException();
    }
}