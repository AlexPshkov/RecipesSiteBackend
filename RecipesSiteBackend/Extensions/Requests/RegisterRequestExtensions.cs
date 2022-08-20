using RecipesSiteBackend.Requests;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions;

public static class RegisterRequestExtensions
{


    public static UserEntity ConvertToUserEntity( this RegisterRequest request )
    {
        return new UserEntity()
        {
            Id = Guid.NewGuid(),
            UserName = request.name,
            Description = "",
            Login = request.login.ToLower(),
            Password = request.password
        };
    }
}