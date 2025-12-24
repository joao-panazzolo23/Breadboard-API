using Breadboard.Shared.Repository;

namespace Breadboard.Infra.PostgreSQL;

public class UnityOfWork(AppDbContext context) : IUnityOfWork
{
    /// <summary>
    /// This method returns an int as how many lines got changed at db
    /// </summary>
    /// <returns></returns>
    public async Task<int> Commit()
        => await context.SaveChangesAsync();

    public async Task Rollback()
        => await context.Database.CurrentTransaction?.RollbackAsync()!;
}