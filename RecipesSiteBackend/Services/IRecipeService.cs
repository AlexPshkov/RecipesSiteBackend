using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Services;

public interface IRecipeService
{
    public Task<List<RecipeEntity>> GetAllRecipes( int start, int end );

    /**
     * <exception cref="NoSuchRecipeException"></exception>
     * <exception cref="NoPermException"></exception>
     */
    public Task<bool> RemoveRecipe( int recipeId, Guid userId );

    /**
     * <exception cref="InvalidRecipeException"></exception>>
     */
    public Task<int> SaveRecipe( RecipeEntity recipeEntity );

    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public Task<RecipeEntity> GetRecipe( int recipeId );

    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public Task<RecipeEntity> HandleLike( int recipeId, Guid userId );

    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public Task<RecipeEntity> HandleFavorite( int recipeId, Guid userId );

    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public Task<RecipeEntity> GetBestRecipe( Action action );

    public Task<List<RecipeEntity>> GetRecipesBySearchQuery( string searchQuery, int start, int end );
    
    public Task<List<TagEntity>> GetBestTags( int amount );
}