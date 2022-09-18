using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Validators;

public static class UserValidators
{
    public static UserEntity ValidateUser( this UserEntity userEntity )
    {
        userEntity.Login = ValidateUserLogin( userEntity.Login );
        userEntity.UserName = ValidateUserName( userEntity.UserName );
        userEntity.Description = ValidateUserDescription( userEntity.Description );
        userEntity.Password = ValidateUserPassword( userEntity.Password );
        
        return userEntity;
    }

    public static string ValidateUserLogin( string login )
    {
        if ( login.IsNullOrEmpty() ) throw new InvalidParamException( "User login is empty" );
        if ( login.Length > 100 ) login = login[..100];
        return login;
    }
    
    public static string ValidateUserName( string userName )
    {
        if ( userName.IsNullOrEmpty() ) throw new InvalidParamException( "User name is empty" );
        if ( userName.Length > 250 ) userName = userName[..250];
        return userName;
    }
    
    public static string ValidateUserDescription( string userDescription )
    {
        if ( userDescription.Length > 500 ) userDescription = userDescription[..500];
        return userDescription;
    }
    
    public static string ValidateUserPassword( string userPassword )
    {
        if ( userPassword.Length > 500 ) userPassword = userPassword[..500];
        return userPassword;
    }
}