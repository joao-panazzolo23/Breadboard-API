using Breadboard.Domain;
using Breadboard.Shared.Entities;

namespace Breadboard.Application;

/// <summary>
/// Yes, this is wrong in DDD theoretical therms.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IGenericRepository<T> where T : Entity
{
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetById(Guid id);
}