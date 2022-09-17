using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Validators;

public static class UserValidators
{
    public static UserEntity ValidateUser( this UserEntity userEntity )
    {
        if ( userEntity.Login.IsNullOrEmpty() ) throw new InvalidUserException( "User login is empty", userEntity );
        
        if ( userEntity.UserName.IsNullOrEmpty() ) throw new InvalidUserException( "User name is empty", userEntity );

        if ( userEntity.Description.Length > 450 ) userEntity.Description = userEntity.Description[..450];
        return userEntity;
    }
}