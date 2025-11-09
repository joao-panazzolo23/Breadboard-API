using Breadboard.Shared.Entities;

namespace Breadboard.Shared;

public interface IGenericRepository<T> where T : Entity
{
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
    Task<T?> GetById(Guid id);
}