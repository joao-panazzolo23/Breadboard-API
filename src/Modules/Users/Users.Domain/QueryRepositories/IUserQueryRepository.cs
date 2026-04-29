using Breadboard.Domain.DTOs;

namespace Breadboard.Domain.QueryRepositories;

/// <summary>
/// Todo: change to its own viewmodel
/// </summary>
public interface IUserQueryRepository 
{
    Task<UserDto?> GetById(Guid id);
    Task<UserDto?> GetByUserName(string username);
    /// <summary>
    /// todo: filters here
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<UserDto>> List();
}