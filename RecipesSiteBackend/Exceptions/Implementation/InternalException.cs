using Microsoft.AspNetCore.Mvc;

namespace RecipesSiteBackend.Exceptions.Implementation;

public class InternalException : AbstractRuntimeException
{
    public InternalException( string message, Exception innerException ) 
        : base( message, innerException )
    {
    }

    private ContentResult GetContentResult()
    {
        return base.GetContentResult( 500 );
    }

    public override ContentResult ContentResult => GetContentResult();
}