using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IUserRepository : IEntityRepository<UserEntity>
{
    public Task<UserEntity?> GetById( Guid id );
    public Task<UserEntity?> GetFullById( Guid id );

    public Task<List<RecipeEntity>> GetCreatedRecipes( Guid userId );
    public Task<List<RecipeEntity>> GetFavorites( Guid userId );
    public Task<List<RecipeEntity>> GetLikes( Guid userId );
    
    public Task<UserEntity?> GetByLogin( string login );

}