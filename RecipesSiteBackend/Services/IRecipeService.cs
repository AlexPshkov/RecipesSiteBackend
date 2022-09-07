using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Services;

public interface IRecipeService
{
    public List<RecipeEntity> GetAllRecipes();

    
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
}