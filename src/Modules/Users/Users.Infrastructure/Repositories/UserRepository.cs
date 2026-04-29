using Breadboard.Domain.Entities;
using Breadboard.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Users.Infrastructure.DbContext;

namespace Users.Infrastructure.Repositories;

//namespace BuildingBlocks.PostgreSQL.Repositories;

//todo: repassar para a infra de users
internal sealed class UserRepository(UserDbContext context) : IUserRepository
{
    public async Task Create(User entity) =>
        await context.Users.AddAsync(entity);


    public void Update(User entity) =>
         context.Users.Entry(entity).State = EntityState.Modified;

    public void Delete(User entity) => context.Users.Remove(entity);

    public Task<User?> GetById(Guid id) => context.Users.FirstOrDefaultAsync(X => X.Id == id);

    public Task<User?> GetByUsername(string username)
        => context.Users.FirstOrDefaultAsync(x => x.Username == username);
}
