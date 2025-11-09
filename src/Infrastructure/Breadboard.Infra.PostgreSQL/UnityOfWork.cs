using Breadboard.Shared;

namespace Breadboard.Infra.PostgreSQL;

public class UnityOfWork : IUnityOfWork
{
    private readonly AppDbContext _context;

    public UnityOfWork(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// This method returns an int as how many lines got changed at db
    /// </summary>
    /// <returns></returns>
    public async Task<int> Commit()
        => await _context.SaveChangesAsync();

    public async Task Rollback()
        => await _context.Database.CurrentTransaction?.RollbackAsync();
}