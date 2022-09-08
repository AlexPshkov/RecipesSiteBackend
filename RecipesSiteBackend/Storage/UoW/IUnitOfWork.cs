namespace RecipesSiteBackend.Storage.UoW;

public interface IUnitOfWork
{
    bool SaveChanges(CancellationToken cancellationToken = default);
}