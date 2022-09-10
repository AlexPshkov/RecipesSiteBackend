using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Services;

public interface IUserService
{
    public UserEntity? GetUserById( Guid id );
    
    /**
     * <remarks>Returns big entity with all children entities</remarks>
     */
    public UserEntity? GetFullUserById( Guid id );
    
    public UserEntity? GetUserByLogin( string login );
    public UserEntity Save( UserEntity userEntity );
    public UserEntity? GetByLoginAndPassword( string login, string password );

    public List<RecipeEntity> GetFavorites( Guid userId );
    public List<RecipeEntity> GetLikes( Guid userId );
    public List<RecipeEntity> GetCreatedRecipes( Guid userId );
}