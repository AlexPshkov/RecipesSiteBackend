using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IRecipeRepository : IEntityRepository<RecipeEntity>
{

    public List<RecipeEntity> GetAll();

    public void Save();
    public RecipeEntity ? GetById(int id);
    public List<RecipeEntity> GetUserRecipes(Guid userId);
    public List<RecipeEntity> GetUserFavorites( Guid userId );

}