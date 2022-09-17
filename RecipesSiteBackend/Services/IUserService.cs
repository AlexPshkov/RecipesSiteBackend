using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Services;

public interface IUserService
{
    public Task<UserEntity?> GetUserById( Guid id );

    /**
     * <remarks>Returns big entity with all children entities</remarks>
     */
    public Task<UserEntity?> GetFullUserById( Guid id );
    
    public Task<UserEntity?> GetUserByLogin( string login );
    public Task<UserEntity> Save( UserEntity userEntity );
    
    public Task<List<RecipeEntity>> GetFavorites( Guid userId );
    public Task<List<RecipeEntity>> GetLikes( Guid userId );
    public Task<List<RecipeEntity>> GetCreatedRecipes( Guid userId );
}