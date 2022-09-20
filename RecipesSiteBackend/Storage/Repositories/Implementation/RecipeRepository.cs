using Microsoft.EntityFrameworkCore;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Repositories.Interfaces;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class RecipeRepository : IRecipeRepository
{
    private readonly DataBaseContext _dbContext;

    public RecipeRepository( DataBaseContext dbContext )
    {
        _dbContext = dbContext;
    }

    public Task<List<RecipeEntity>> GetAll( int start, int end )
    {
        return _dbContext.Recipes
            .OrderByDescending( x => x.RecipeId )
            .Skip( start - 1 )
            .Take( end - start + 1 )
            .ToListAsync();
    }

    public Task<RecipeEntity?> GetById( int id )
    {
        return _dbContext.Recipes.SingleOrDefaultAsync( recipe => id.Equals( recipe.RecipeId ) );
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
        var currentDay = DateTimeOffset.Now.DayOfYear;
        var actions = _dbContext.RecipeActions
            .Where( entity => ( entity.Action == action ) && ( entity.ActionDay == currentDay ) )
            .GroupBy( x => x.RecipeId )
            .Select( x => new { id = x.Key, count = x.Count() } )
            .OrderByDescending( x => x.count );

        var recipe = await actions.FirstOrDefaultAsync();
        if ( recipe == null )
        {
            throw new NoBestRecipeException();
        }

        return await GetById( recipe.id );
    }

    public async Task<List<RecipeEntity>> GetRecipesBySearchQuery( string searchQuery, int start, int end )
    {
        var recipesByName = _dbContext.Recipes
            .Where( x => x.RecipeName.Contains( searchQuery ) )
            .Select( x => x.RecipeId );

        var recipesByTag = _dbContext.Tags
            .Where( x => x.Name.Contains( searchQuery ) )
            .Include( x => x.Recipes )
            .SelectMany( x => x.Recipes, ( entity, recipeEntity ) => recipeEntity.RecipeId )
            .Distinct();

        var totalRecipeIds = await recipesByName
            .Union( recipesByTag )
            .OrderByDescending( id => id )
            .Skip( start - 1 )
            .Take( end - start + 1 )
            .ToListAsync();
        
        var totalRecipes = await _dbContext.Recipes
            .Where( x => totalRecipeIds.Contains( x.RecipeId ) )
            .ToListAsync();

        return totalRecipes;
    }
}