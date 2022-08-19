using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class IngredientRepository : IIngredientRepository
{
    
    private readonly DataBaseContext _dbContext;

    public IngredientRepository (DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<IngredientEntity> GetAll()
    {
        return _dbContext.Ingredients.ToList();
    }

    public IngredientEntity ? GetById( int id )
    {
        return _dbContext.Ingredients.SingleOrDefault(ing => id.Equals( ing.Id ));
    }
    
    public void Create( IngredientEntity entity )
    {
        _dbContext.Ingredients.Add( entity );
        _dbContext.SaveChanges();
    }

    public void Update( IngredientEntity entity )
    {
        _dbContext.Ingredients.Update( entity );
        _dbContext.SaveChanges();
    }

    public void Delete( IngredientEntity entity )
    {
        _dbContext.Ingredients.Remove( entity );
        _dbContext.SaveChanges();
    }
}