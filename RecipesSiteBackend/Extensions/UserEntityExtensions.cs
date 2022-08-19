using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions;

public static class UserEntityExtensions
{
    
    public static UserDto ConvertToUserDto( this UserEntity ?  userEntity )
    {
        if ( userEntity == null ) return new UserDto();
        return new UserDto()
        {
            id = userEntity.Id.ToString(),
            userName = userEntity.UserName,
            description = userEntity.Description,
            login = userEntity.Login,
            role = userEntity.Role.ToString()
        };
    } 
}