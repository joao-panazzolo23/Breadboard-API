using Breadboard.Shared;

namespace Breadboard.Infra.PostgreSQLDapper;

public class UnityOfWork : IUnityOfWork
{
    public UnityOfWork()
    {
        
    }
    public Task Commit()
    {
        throw new NotImplementedException();
    }

    public Task Rollback()
    {
        throw new NotImplementedException();
    }
}