using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Services;

public interface ITokenService
{
    public string GetToken( UserEntity userEntity );
}