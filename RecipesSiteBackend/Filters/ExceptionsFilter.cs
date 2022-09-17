using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RecipesSiteBackend.Exceptions;

namespace RecipesSiteBackend.Filters;

public class ExceptionsFilter : IExceptionFilter
{
    public void OnException( ExceptionContext context )
    {
        if ( context.Exception is AbstractRuntimeException )
        {
            var baseException = (AbstractRuntimeException) context.Exception.GetBaseException();
            context.Result = baseException.ContentResult;
            return;
        }

        context.Result = new ContentResult()
        {
            StatusCode = 500,
            Content = context.Exception.Message
        };

    }
}