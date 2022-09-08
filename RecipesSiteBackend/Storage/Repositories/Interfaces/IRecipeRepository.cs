using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IRecipeRepository : IEntityRepository<RecipeEntity>
{
    public List<RecipeEntity> GetAll();
    
    public RecipeEntity ? GetById(int id);
}