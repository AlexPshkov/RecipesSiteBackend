using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions.Entity;

public static class UserEntityExtensions
{
    /**
     * <exception cref="NoSuchUserException"></exception>
     */
    public static UserDto ConvertToUserDto( this UserEntity?  userEntity )
    {
        if ( userEntity == null )
        {
            throw new NoSuchUserException();
        }
        return new UserDto
        {
            UserName = userEntity.UserName,
            Description = userEntity.Description,
            Login = userEntity.Login,
            Role = userEntity.Role.ToString()
        };
    } 
    
    /**
     * <exception cref="NoSuchUserException"></exception>
     */
    public static UserStatisticDto ConvertToUserStatisticDto( this UserEntity?  userEntity )
    {
        if ( userEntity == null )
        {
            throw new NoSuchUserException();
        }

        var createdRecipes = userEntity.CreatedRecipes;
        var totalLikes = 0;
        var totalFavorites = 0;
        createdRecipes.ForEach( x => totalLikes += x.Likes.Count );
        createdRecipes.ForEach( x => totalFavorites += x.Favorites.Count );
        
        return new UserStatisticDto()
        {
            CreatedRecipesAmount = createdRecipes.Count,
            LikedRecipesAmount = totalLikes,
            FavoritesRecipesAmount = totalFavorites
        };
    } 
    
    /**
     * <exception cref="NoSuchUserException"></exception>
     */
    public static UserEntity Combine( this UserEntity?  userEntity, UserEntity? newUserEntity )
    {
        if ( userEntity == null || newUserEntity == null )
        {
            throw new NoSuchUserException();
        }

        userEntity.UserName = newUserEntity.UserName;
        userEntity.Description = newUserEntity.Description;
        userEntity.Login = newUserEntity.Login;
        
        if ( !newUserEntity.Password.IsNullOrEmpty() )
        {
            userEntity.Password = newUserEntity.Password;
        }
        return userEntity;
    } 
}