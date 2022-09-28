using RecipesSiteBackend.Storage.Entities.Implementation;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IRecipeRepository : IEntityRepository<RecipeEntity>
{
    public Task<List<RecipeEntity>> GetAll( int start, int end );

    public Task<List<RecipeEntity>> GetRecipesBySearchQuery( string searchQuery, int start, int end );
    public Task<RecipeEntity?> GetBestRecipe( Action action );
    public Task<RecipeEntity?> GetById( int id );
}