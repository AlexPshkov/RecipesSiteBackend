using RecipesSiteBackend.Storage.Repositories;

namespace RecipesSiteBackend.Storage.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _ctx;

    public UnitOfWork(DataBaseContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<bool> SaveChanges(CancellationToken cancellationToken = default)
    {
        var result = await _ctx.SaveChangesAsync( cancellationToken );
        return result > 0;
    }
}