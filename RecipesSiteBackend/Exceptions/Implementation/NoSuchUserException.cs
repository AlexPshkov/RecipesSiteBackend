using Microsoft.AspNetCore.Mvc;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class NoSuchUserException : AbstractRuntimeException
{
    public NoSuchUserException()
    {
    }
    
    public NoSuchUserException( Guid userId ) 
        : base( $"No such user with ID: {userId}" )
    {
    }
    
    public NoSuchUserException( string userLogin ) 
        : base( $"No such user with Login: {userLogin}" )
    {
    }
    
    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 404 );
    }

    public override ContentResult ContentResult => GetContentResult();
}