using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class InvalidRecipeException : AbstractRuntimeException
{

    public InvalidRecipeException()
    {
    }
    
    public InvalidRecipeException( string message, RecipeEntity recipeEntity ) 
        : base($"Invalid recipe {recipeEntity} Error: {message}")
    {
    }

    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 412 );
    }

    public override ContentResult? ContentResult => GetContentResult();
}