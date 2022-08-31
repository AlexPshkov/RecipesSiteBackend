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

    public List<RecipeEntity> GetUserRecipes( Guid userId )
    {
        return _dbContext.Recipes.Where( recipe => recipe.UserId.Equals( userId ) ).ToList();
    }

    public List<RecipeEntity> GetUserFavorites( Guid userId )
    {
        var favorites = _dbContext.Favorites.Where( favorite => favorite.UserId.Equals( userId ) ).ToList();
        return favorites.ConvertAll( input => input.Recipe );
    }
    
    public void Create( RecipeEntity entity )
    {
        _dbContext.Recipes.Add( entity );
        Save();
    }

    public void Update( RecipeEntity entity )
    {
        _dbContext.Recipes.Update( entity );
        Save();
    }

    public void Delete( RecipeEntity entity )
    {
        _dbContext.Recipes.Remove( entity );
        Save();
    }
    
    public void Save( )
    {
        _dbContext.SaveChanges();
    }
}