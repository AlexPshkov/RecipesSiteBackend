namespace RecipesSiteBackend.Exceptions;

public class NoPermException : Exception
{
    public NoPermException()
    {
    }

    public NoPermException( string message) : base($"No permissions. Error: {message}")
    {
    }

    public NoPermException( string message, Exception inner ) : base( message, inner )
    {
    }
}