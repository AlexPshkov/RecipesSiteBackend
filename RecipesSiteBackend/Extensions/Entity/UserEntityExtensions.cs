using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions.Entity;

public static class UserEntityExtensions
{
    
    public static UserDto ConvertToUserDto( this UserEntity ?  userEntity )
    {
        if ( userEntity == null )
        {
            return new UserDto();
        }
        return new UserDto()
        {
            Id = userEntity.UserId.ToString(),
            UserName = userEntity.UserName,
            Password = userEntity.Password,
            Description = userEntity.Description,
            Login = userEntity.Login,
            Role = userEntity.Role.ToString()
        };
    } 
}