using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IFavoriteRepository : IEntityRepository<FavoriteEntity>
{

    public List<FavoriteEntity> GetAll();
    
    
    public FavoriteEntity ? GetById(int id);
    public List<FavoriteEntity> GetUserFavorites(Guid userId);
    public List<FavoriteEntity> GetRecipeFavorites(int recipeId);
    
}