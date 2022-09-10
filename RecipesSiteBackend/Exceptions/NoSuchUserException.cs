﻿namespace RecipesSiteBackend.Exceptions;

public class NoSuchUserException : Exception
{
    public NoSuchUserException()
    {
    }

    public NoSuchUserException( Guid userId ) : base($"No such user with ID: {userId}")
    {
    }
    
    public NoSuchUserException( string userLogin ) : base($"No such user with Login: {userLogin}")
    {
    }

    public NoSuchUserException( string message, Exception inner ) : base( message, inner )
    {
    }
}