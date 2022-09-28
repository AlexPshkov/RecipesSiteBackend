using Microsoft.AspNetCore.Mvc;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class NoPermException : AbstractRuntimeException
{
    public NoPermException( string message) 
        : base( $"No permissions. Error: {message}" )
    {
    }
    

    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 403 );
    }

    public override ContentResult ContentResult => GetContentResult();
}