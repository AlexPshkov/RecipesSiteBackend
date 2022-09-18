using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class InvalidUserException : AbstractRuntimeException
{
    public InvalidUserException()
    {
    }
    
    public InvalidUserException( string message, UserEntity userEntity ) 
        : base($"Invalid user {userEntity} Error: {message}")
    {
    }
    
    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 412 );
    }

    public override ContentResult? ContentResult => GetContentResult();
}