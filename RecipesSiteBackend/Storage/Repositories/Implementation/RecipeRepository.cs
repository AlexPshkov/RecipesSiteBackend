using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class RecipeRepository : IRecipeRepository
{
    
    private readonly DataBaseContext _dbContext;

    public RecipeRepository (DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<RecipeEntity> GetAll()
    {
        return _dbContext.Recipes.ToList();
    }

    public RecipeEntity ? GetById( int id )
    {
        return _dbContext.Recipes.SingleOrDefault(recipe => id.Equals( recipe.RecipeId ));
    }

    public void Create( RecipeEntity entity )
    {
        var userEntity = _dbContext.UserAccounts.SingleOrDefault( userEntity => userEntity.UserId == entity.UserId );
        entity.User = userEntity!;
        userEntity!.CreatedRecipes.Add( entity );
    }

    public void Update( RecipeEntity entity )
    {
        _dbContext.Recipes.Update( entity );
    }

    public void Delete( RecipeEntity entity )
    {
        _dbContext.Recipes.Remove( entity );
    }
}