using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Exceptions;

namespace RecipesSiteBackend.Services;

public interface IRecipeService
{
    public List<RecipeDto> GetAllRecipes();
    
    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public RecipeDto GetRecipe( int recipeId );
    
    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public RecipeDto HandleLike( int recipeId, Guid userId );
    
    /**
     * <exception cref="NoSuchRecipeException"></exception>
     */
    public RecipeDto HandleFavorite( int recipeId, Guid userId );
}