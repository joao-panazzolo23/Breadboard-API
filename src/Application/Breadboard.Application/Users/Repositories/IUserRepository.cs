using Breadboard.Domain.Users.Entities;

namespace Breadboard.Application.Users.Repositories;

public interface IUserRepository
{
    Task<User?> GetByUsername(string username);
    Task<User?> GetById(Guid id);
    void Delete(User user);
    void Update(User user);
    Task Create(User user);
}