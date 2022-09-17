using Microsoft.AspNetCore.Mvc;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class NoBestRecipeException : AbstractRuntimeException
{
    public NoBestRecipeException() 
        : base( "There is no best recipe" )
    {
    }
    
    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 507 );
    }

    public override ContentResult? ContentResult => GetContentResult();
}