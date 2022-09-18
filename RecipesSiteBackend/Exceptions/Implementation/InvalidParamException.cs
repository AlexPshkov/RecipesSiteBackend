using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class InvalidParamException : AbstractRuntimeException
{
    public InvalidParamException()
    {
    }
    
    public InvalidParamException( string message, string paramName = "parameter" ) 
        : base($"Invalid {paramName}: {message}")
    {
    }
    
    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 412 );
    }

    public override ContentResult? ContentResult => GetContentResult();
}