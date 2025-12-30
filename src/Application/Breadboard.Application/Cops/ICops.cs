using Breadboard.Shared.Results;

namespace Breadboard.Shared.Cops;
/// <summary>
/// Command Operations Processing Service (COPS)
/// </summary>
public interface ICops
{
    /// <summary>
    /// /// Yes, I intended to do it. That's why the service is called COPS. To dispatch Cops.
    /// </summary>
    /// <param name="request"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    Task<Result<TResponse>> Dispatch<TResponse>(object request);
}