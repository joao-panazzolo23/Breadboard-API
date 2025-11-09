using Breadboard.Shared;
using Breadboard.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Breadboard.Infra.PostgreSQL.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>
    where T : Entity
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task Add(T entity) => await _dbSet.AddAsync(entity);

    public Task Update(T entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
            _dbSet.Remove(entity);
    }
    public async Task<T?> GetById(Guid id) => await _dbSet.FindAsync(id);
}