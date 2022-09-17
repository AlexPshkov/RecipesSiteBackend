using RecipesSiteBackend.Storage.Entities.Implementation;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IRecipeRepository : IEntityRepository<RecipeEntity>
{
    public Task<List<RecipeEntity>> GetAll();

    public Task<List<RecipeEntity>> MakeSearch( string searchQuery );
    public Task<RecipeEntity?> GetBestRecipe( Action action );
    public Task<RecipeEntity?> GetById( int id );
}