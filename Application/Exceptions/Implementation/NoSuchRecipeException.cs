using Microsoft.AspNetCore.Mvc;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class NoSuchRecipeException : AbstractRuntimeException
{
    public NoSuchRecipeException()
    {
    }
    
    public NoSuchRecipeException( int recipeId ) 
        : base( $"No such recipe with ID:{recipeId}" )
    {
    }
    
    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 404 );
    }

    public override ContentResult ContentResult => GetContentResult();
}