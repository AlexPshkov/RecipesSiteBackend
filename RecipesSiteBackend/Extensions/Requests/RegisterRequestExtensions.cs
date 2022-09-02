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
            UserName = request.name,
            Description = "",
            Login = request.login.ToLower(),
            Password = request.password
        };
    }
}