namespace Breadboard.Application.Data;

public interface IUnityOfWork
{
    Task<int> Commit();
    Task Rollback();
}