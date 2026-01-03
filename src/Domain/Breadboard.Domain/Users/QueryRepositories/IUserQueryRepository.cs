using Breadboard.Domain.Users.DTOs;

namespace Breadboard.Domain.Users.QueryRepositories;

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