﻿using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Validators;

public static class UserValidators
{
    public static UserEntity ValidateUser( this UserEntity userEntity )
    {
        ValidateLogin( userEntity.Login );
        ValidateName( userEntity.UserName );
        ValidateDescription( userEntity.Description );
        ValidatePassword( userEntity.Password );

        return userEntity;
    }

    public static string ValidateLogin( string login )
    {
        if ( login.IsNullOrEmpty() ) throw new InvalidParamException( "User login is empty" );
        if ( login.Length > 100  ) throw new InvalidParamException( "User login is too big" );

        return login;
    }
    
    public static string ValidateName( string userName )
    {
        if ( userName.IsNullOrEmpty() ) throw new InvalidParamException( "User name is empty" );
        if ( userName.Length > 250 ) throw new InvalidParamException( "User name is too big" );

        return userName;
    }
    
    public static string ValidateDescription( string userDescription )
    {
        if ( userDescription.Length > 500 ) throw new InvalidParamException( "User description is too big" );

        return userDescription;
    }
    
    public static string ValidatePassword( string userPassword )
    {
        if ( userPassword.Length > 500 ) throw new InvalidParamException( "User password is too big" );

        return userPassword;
    }
}