using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions.Entity;

public static class UserEntityExtensions
{
    
    public static UserDto ConvertToUserDto( this UserEntity ?  userEntity )
    {
        if ( userEntity == null ) return new UserDto();
        return new UserDto()
        {
            id = userEntity.UserId.ToString(),
            userName = userEntity.UserName,
            password = userEntity.Password,
            description = userEntity.Description,
            login = userEntity.Login,
            role = userEntity.Role.ToString()
        };
    } 
}