using RecipesSiteBackend.Requests;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions.Requests;

public static class RegisterRequestExtensions
{
    
    public static UserEntity ConvertToUserEntity( this RegisterRequest request )
    {
        return new UserEntity
        {
            UserId = Guid.NewGuid(),
            UserName = request.Name,
            Description = "",
            Login = request.Login.ToLower(),
            Password = request.Password
        };
    }
}