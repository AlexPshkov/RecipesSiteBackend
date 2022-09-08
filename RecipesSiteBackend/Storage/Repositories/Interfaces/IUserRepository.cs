using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IUserRepository : IEntityRepository<UserEntity>
{

    public List<UserEntity> GetAll();
    
    public UserEntity ?  GetById(Guid id);

    public List<RecipeEntity> GetCreatedRecipes( Guid userId );
    public List<RecipeEntity> GetFavorites( Guid userId );
    public List<RecipeEntity> GetLikes( Guid userId );
    
    public UserEntity ?  GetByLogin(string login);

}