using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions.Dto;

public static class UserDtoExtensions
{
    public static UserEntity ConvertToUserEntity( this UserDto dto )
    {
        return new UserEntity()
        {
            UserId = Guid.Parse(dto.id),
            UserName = dto.userName,
            Login = dto.login,
            Password = dto.password,
            Description = dto.description,
            Role = Enum.TryParse( dto.role, out Role role) ? role : Role.User
        };
    }
} 