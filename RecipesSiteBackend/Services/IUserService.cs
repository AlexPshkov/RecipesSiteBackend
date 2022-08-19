using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Services;

public interface IUserService
{
    public UserEntity ? GetUserById( Guid id );
    public UserEntity ? GetUserByLogin( string login );
    public void Save( UserEntity userEntity );
    public UserEntity ? GetByLoginAndPassword(string login, string password);
}