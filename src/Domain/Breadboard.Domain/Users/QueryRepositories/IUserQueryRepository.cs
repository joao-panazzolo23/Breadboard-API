namespace Breadboard.Domain.Users.QueryRepositories;

/// <summary>
/// Todo: change to its own viewmodel
/// </summary>
public interface IUserQueryRepository
{
    Task<dynamic?> GetById(Guid id);
    /// <summary>
    /// todo: filters here
    /// </summary>
    /// <returns></returns>
    Task<dynamic> List();
}