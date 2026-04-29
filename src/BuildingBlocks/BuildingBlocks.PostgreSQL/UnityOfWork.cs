using Breadboard.Application.Data;

namespace BuildingBlocks.PostgreSQL;

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