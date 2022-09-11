using RecipesSiteBackend.Storage.Entities.Implementation;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IRecipeRepository : IEntityRepository<RecipeEntity>
{
    public List<RecipeEntity> GetAll();

    public RecipeEntity? GetBestRecipe( Action action );
    public RecipeEntity? GetById( int id );
}