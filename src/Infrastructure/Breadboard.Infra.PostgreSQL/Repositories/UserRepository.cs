using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.Repositories;

namespace Breadboard.Infra.PostgreSQL.Repositories;

internal class UserRepository(AppDbContext context) : IUserRepository
{
    public Task Create(User entity)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsername(string username)
    {
        throw new NotImplementedException();
    }
}