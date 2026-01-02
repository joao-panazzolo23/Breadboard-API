using Breadboard.Application;
using Breadboard.Domain;
using Microsoft.EntityFrameworkCore;

namespace Breadboard.Infra.PostgreSQL.Repositories;

/// <summary>
/// Generic repositories aren't a thing anymore in DDD context.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="context"></param>
public abstract class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>
    where T : Entity
{
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task Create(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) =>
       _dbSet.Entry(entity).State = EntityState.Modified;


    public void Delete(T entity) =>
           _dbSet.Remove(entity);

    public async Task<T?> GetById(Guid id) => await _dbSet.FindAsync(id);
}