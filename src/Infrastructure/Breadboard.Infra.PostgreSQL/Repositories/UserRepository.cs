using Breadboard.Domain.Users.Entities;
using Breadboard.Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Breadboard.Infra.PostgreSQL.Repositories;

internal class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task Create(User entity) =>
        await context.Users.AddAsync(entity);


    public void Update(User entity) =>
         context.Users.Entry(entity).State = EntityState.Modified;

    public void Delete(User entity) => context.Users.Remove(entity);

    public Task<User?> GetById(Guid id) => context.Users.FirstOrDefaultAsync(X => X.Id == id);

    public Task<User?> GetByUsername(string username) 
        => context.Users.FirstOrDefaultAsync(x=> x.Username == username);
}