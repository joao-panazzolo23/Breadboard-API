using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Breadboard.Infra.PostgreSQL.Repositories;

internal class UserRepository(AppDbContext context) : GenericRepository<User>(context), IUserRepository
{
    /// <summary>
    /// Isn't it supposed to be for query repository?
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public Task<User?> GetByUsername(string username)
    {
        return _dbSet.FirstOrDefaultAsync(x => x.Username == username);
    }
}