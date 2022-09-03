using RecipesSiteBackend.Storage.Repositories;

namespace RecipesSiteBackend.Storage.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _ctx;

    public UnitOfWork(DataBaseContext ctx)
    {
        _ctx = ctx;
    }

    public bool SaveChanges(CancellationToken cancellationToken = default)
    {
        return _ctx.SaveChanges() > 0;
    }
}