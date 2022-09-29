using Microsoft.AspNetCore.Mvc;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class UserAlreadyExistsException : AbstractRuntimeException
{
    public UserAlreadyExistsException( string login ) 
        : base( $"User with login = {login} already exists" )
    {
    }
    
    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 423 );
    }

    public override ContentResult ContentResult => GetContentResult();
}