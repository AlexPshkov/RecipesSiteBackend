namespace RecipesSiteBackend.Exceptions;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException()
    {
    }

    public UserAlreadyExistsException( string login ) : base($"User with login = {login} already exists")
    {
    }

    public UserAlreadyExistsException( string message, Exception inner ) : base( message, inner )
    {
    }
}