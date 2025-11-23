namespace Breadboard.Shared.Repository;

public interface IUnityOfWork
{
    Task<int> Commit();
    Task Rollback();
}