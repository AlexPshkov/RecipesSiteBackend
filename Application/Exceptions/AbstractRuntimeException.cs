using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto.Responses;

namespace RecipesSiteBackend.Exceptions;

public abstract class AbstractRuntimeException : Exception
{
    public abstract ContentResult? ContentResult { get; }

    protected AbstractRuntimeException()
    {
    }

    protected AbstractRuntimeException( string message, Exception inner ) : base( message, inner )
    {
    }

    protected AbstractRuntimeException( string message ) : base( message )
    {
    }

    protected ContentResult GetContentResult( int statusCode )
    {
        var exceptionDto = new ErrorDto()
        {
            Message = base.Message,
            StatusCode = statusCode
        };
        
        return new ContentResult
        {
            Content = JsonSerializer.Serialize( exceptionDto ),
            StatusCode = statusCode
        };
    }
}