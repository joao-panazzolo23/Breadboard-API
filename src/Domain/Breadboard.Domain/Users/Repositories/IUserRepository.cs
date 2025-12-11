using Breadboard.Domain.Users.Entities;

namespace Breadboard.Domain.Users.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUsername(string username);
}