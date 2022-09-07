namespace RecipesSiteBackend.Exceptions;

public class NoSuchRecipeException : Exception
{
    public NoSuchRecipeException()
    {
    }

    public NoSuchRecipeException( int recipeId ) : base( $"No such recipe with ID:{recipeId}" )
    {
    }

    public NoSuchRecipeException( string message, Exception inner ) : base( message, inner )
    {
    }
}