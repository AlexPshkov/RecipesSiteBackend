using Microsoft.EntityFrameworkCore;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Repositories.Interfaces;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class RecipeRepository : IRecipeRepository
{
    
    private readonly DataBaseContext _dbContext;

    public RecipeRepository ( DataBaseContext dbContext )
    {
        _dbContext = dbContext;
    }
    
    public Task<List<RecipeEntity>> GetAll()
    {
        return _dbContext.Recipes.ToListAsync();
    }

    public Task<RecipeEntity?> GetById( int id )
    {
        return _dbContext.Recipes.SingleOrDefaultAsync( recipe => id.Equals( recipe.RecipeId ));
    }
    
    public async void Create( RecipeEntity entity )
    {
        await _dbContext.Recipes.AddAsync( entity );
    }

    public void Update( RecipeEntity entity )
    {
        _dbContext.Recipes.Update( entity );
    }

    public void Delete( RecipeEntity entity )
    {
        _dbContext.Recipes.Remove( entity );
    }
    
    public async Task<RecipeEntity?> GetBestRecipe( Action action )
    {
        var actions = _dbContext.RecipeActions.Where( recipe => recipe.Action == action );
        var recipes = actions
            .Include( x => x.Recipe )
            .Where( x => x.Action == action )
            .GroupBy( x => x.RecipeId )
            .Select( x => new { id = x.Key, count = x.Count() } )
            .OrderByDescending( x => x.count );
       
        var recipe = await recipes.FirstOrDefaultAsync();
        if ( recipe == null )
        {
            throw new NoBestRecipeException();
        }
        return await GetById( recipe.id );
    }
    
    public async Task<List<RecipeEntity>> MakeSearch( string searchQuery )
    {
        var recipes = _dbContext.Recipes
            .Where( x => searchQuery.Contains( x.RecipeName ) || x.RecipeName.Contains( searchQuery ) )
            .ToHashSet();
        var tags = _dbContext.Tags
            .Include( x => x.Recipes )
            .Where( x => searchQuery.Contains( x.Name ) );
        await tags.ForEachAsync( tag => recipes.UnionWith( tag.Recipes ) );
        
        return recipes.ToList();
    } 
}