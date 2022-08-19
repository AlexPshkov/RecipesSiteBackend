using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IUserRepository : IEntityRepository<UserEntity>
{

    public List<UserEntity> GetAll();
    
    
    public UserEntity ?  GetById(Guid id);
    
    
    public UserEntity ?  GetByLogin(string login);

}