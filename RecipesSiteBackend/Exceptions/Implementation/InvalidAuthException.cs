using Microsoft.AspNetCore.Mvc;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class InvalidAuthException : AbstractRuntimeException
{
    public InvalidAuthException() 
        : base("Invalid login or password" )
    {
    }

    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 401 );
    }

    public override ContentResult ContentResult => GetContentResult();
}