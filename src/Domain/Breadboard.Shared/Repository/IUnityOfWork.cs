using System.Transactions;

namespace Breadboard.Shared;

public interface IUnityOfWork
{
    Task<int> Commit();
    Task Rollback();
}