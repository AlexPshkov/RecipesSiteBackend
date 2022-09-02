using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions.Dto;

public static class UserDtoExtensions
{
    public static UserEntity ConvertToUserEntity( this UserDto dto )
    {
        return new UserEntity()
        {
            UserId = Guid.Parse(dto.Id),
            UserName = dto.UserName,
            Login = dto.Login,
            Password = dto.Password,
            Description = dto.Description,
            Role = Enum.TryParse( dto.Role, out Role role) ? role : Role.User
        };
    }
} 