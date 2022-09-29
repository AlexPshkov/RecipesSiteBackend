using Microsoft.AspNetCore.Mvc;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class InvalidParamException : AbstractRuntimeException
{
    public InvalidParamException( string message, string paramName = "parameter" ) 
        : base( $"Invalid {paramName}: {message}" )
    {
    }
    
    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 412 );
    }

    public override ContentResult ContentResult => GetContentResult();
}