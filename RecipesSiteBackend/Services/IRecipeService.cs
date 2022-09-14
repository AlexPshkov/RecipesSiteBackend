using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Storage.Entities.Implementation;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Services;

public interface IRecipeService
{
    public List<RecipeEntity> GetAllRecipes();

    /**
     * <exception cref="NoSuchRecipeException"></exception>
     * <exception cref="NoPermException"></exception>
     */
    public void RemoveRecipe( int recipeId, Guid userId );
    
    /**
     * <exception cref="InvalidRecipeException"></exception>>
     */
    public int SaveRecipe( RecipeEntity recipeEntity );
    
    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public RecipeEntity GetRecipe( int recipeId );
    
    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public RecipeEntity HandleLike( int recipeId, Guid userId );
    
    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public RecipeEntity HandleFavorite( int recipeId, Guid userId );

    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public RecipeEntity GetBestRecipe( Action action );

    public Task<List<RecipeEntity>> MakeSearch( string searchQuery );
}