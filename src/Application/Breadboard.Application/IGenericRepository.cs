using Breadboard.Shared.Entities;

namespace Breadboard.Shared.Repository;

public interface IGenericRepository<T> where T : Entity
{
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetById(Guid id);
}