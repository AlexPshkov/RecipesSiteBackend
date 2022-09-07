using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Exceptions;

public class InvalidRecipeException : Exception
{
    public InvalidRecipeException()
    {
    }

    public InvalidRecipeException( string message, RecipeEntity recipeEntity ) : base($"Invalid recipe {recipeEntity} Error: {message}")
    {
    }

    public InvalidRecipeException( string message, Exception inner ) : base( message, inner )
    {
    }
}