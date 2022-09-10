using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Exceptions;

public class InvalidUserException : Exception
{
    public InvalidUserException()
    {
    }

    public InvalidUserException( string message, UserEntity userEntity ) : base($"Invalid user {userEntity} Error: {message}")
    {
    }

    public InvalidUserException( string message, Exception inner ) : base( message, inner )
    {
    }
}