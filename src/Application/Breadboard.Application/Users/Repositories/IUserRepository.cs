using Breadboard.Domain.Users.Entities;

namespace Breadboard.Application.Users.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByUsername(string username);
}