using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface ILikeRepository : IEntityRepository<LikeEntity>
{

    public List<LikeEntity> GetAll();
    
    
    public LikeEntity ? GetById(int id);
    public List<LikeEntity> GetUserLikes(Guid userId);
    public List<LikeEntity> GetRecipeLikes(int recipeId);
    
}