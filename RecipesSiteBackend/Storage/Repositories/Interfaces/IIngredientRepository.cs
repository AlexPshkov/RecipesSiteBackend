using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IIngredientRepository : IEntityRepository<IngredientEntity>
{

    public List<IngredientEntity> GetAll();
    
    
    public IngredientEntity ?  GetById(int id);
    
}