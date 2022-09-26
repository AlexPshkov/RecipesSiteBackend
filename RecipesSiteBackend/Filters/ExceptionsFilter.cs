using Microsoft.AspNetCore.Mvc.Filters;
using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Exceptions.Implementation;

namespace RecipesSiteBackend.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionsFilter> _logger;

    public ExceptionsFilter( ILogger<ExceptionsFilter> logger )
    {
        _logger = logger;
    }
    
    public void OnException( ExceptionContext context )
    {
        AbstractRuntimeException abstractRuntimeException;
        if ( context.Exception is AbstractRuntimeException )
        {
            abstractRuntimeException = (AbstractRuntimeException) context.Exception.GetBaseException();
            _logger.LogWarning( "{ExceptionMessage}", abstractRuntimeException.Message );
        }
        else
        {
            abstractRuntimeException = new InternalException( "Error on handling request", context.Exception );
            _logger.LogWarning( context.Exception, "Error on handling request" );
        }

        context.Result = abstractRuntimeException.ContentResult;
    }
}