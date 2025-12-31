using Breadboard.Application;
using Breadboard.Domain.Users.Entities;
using Breadboard.Shared.Repository;

namespace Breadboard.Domain.Users.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByUsername(string username);
}