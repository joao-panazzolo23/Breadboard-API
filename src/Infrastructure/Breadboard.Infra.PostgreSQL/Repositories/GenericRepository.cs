using Breadboard.Shared.Entities;
using Breadboard.Shared.Repository;
using Microsoft.EntityFrameworkCore;

namespace Breadboard.Infra.PostgreSQL.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>
    where T : Entity
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task Create(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => 
       _dbSet.Entry(entity).State = EntityState.Modified;
    

    public void Delete(T entity) => 
           _dbSet.Remove(entity);
    
    public async Task<T?> GetById(Guid id) => await _dbSet.FindAsync(id);
}