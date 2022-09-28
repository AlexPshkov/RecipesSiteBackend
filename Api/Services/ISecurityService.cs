using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Services;

public interface ISecurityService
{
    public string HashPassword( string password );
    public bool VerifyPassword( string password, string passwordHash );
    public string GetToken( UserEntity userEntity );
}