using RecipesSiteBackend.Storage.Entities;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IEntityRepository<in T> where T : AbstractEntity
{
    public void Create( T entity );
    public void Update( T entity );
    public void Delete( T entity );
}