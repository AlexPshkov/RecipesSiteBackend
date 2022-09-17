namespace RecipesSiteBackend.Storage.UoW;

public interface IUnitOfWork
{
    public Task<bool> SaveChanges( CancellationToken cancellationToken = default );
}