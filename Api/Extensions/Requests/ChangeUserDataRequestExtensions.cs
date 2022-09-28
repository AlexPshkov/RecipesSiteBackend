using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Dto.Requests;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions.Requests;

public static class ChangeUserDataRequestExtensions
{
    public static UserEntity ConvertToUserEntity( this ChangeUserDataRequest request, Guid userId )
    {
        return new UserEntity
        {
            UserId = userId,
            UserName = request.UserName,
            Login = request.Login.ToLower(),
            Password = request.Password.IsNullOrEmpty() ? "" : BCrypt.Net.BCrypt.HashPassword( request.Password ),
            Description = request.Description,
            Role = Enum.TryParse( request.Role, out Role role) ? role : Role.User
        };
    }
}