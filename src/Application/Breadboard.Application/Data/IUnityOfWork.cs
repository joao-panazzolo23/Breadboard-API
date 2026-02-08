namespace Breadboard.Application;

public interface IUnityOfWork
{
    Task<int> Commit();
    Task Rollback();
}