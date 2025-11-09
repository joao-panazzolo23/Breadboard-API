using System.Transactions;

namespace Breadboard.Shared;

public interface IUnityOfWork
{
    Task Commit();
    Task Rollback();
}