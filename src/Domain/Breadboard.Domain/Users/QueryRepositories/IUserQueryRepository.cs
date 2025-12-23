using Breadboard.Domain.Users.Viewmodels;

namespace Breadboard.Domain.Users.QueryRepositories;

/// <summary>
/// Todo: change to its own viewmodel
/// </summary>
public interface IUserQueryRepository
{
    Task<UserViewmodel?> GetById(Guid id);
    Task<UserViewmodel?> GetByUserName(string username);
    /// <summary>
    /// todo: filters here
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<UserViewmodel>> List();
}