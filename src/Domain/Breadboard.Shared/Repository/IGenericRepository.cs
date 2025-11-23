using Breadboard.Shared.Entities;

namespace Breadboard.Shared.Repository;

public interface IGenericRepository<T> where T : Entity
{
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
    Task<T?> GetById(Guid id);
}