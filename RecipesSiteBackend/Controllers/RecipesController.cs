using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Dto.Responses;
using RecipesSiteBackend.Extensions.Dto;
using RecipesSiteBackend.Extensions.Entity;
using RecipesSiteBackend.Filters;
using RecipesSiteBackend.Services;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
[TypeFilter( typeof( ExceptionsFilter ) )]
public class RecipesController : Controller
{
    private Guid? UserId
    {
        get
        {
            var isAuthed = User.Claims.Any( x => x.Type == ClaimTypes.NameIdentifier );
            if ( isAuthed )
            {
                return Guid.Parse( User.Claims.Single( c => c.Type == ClaimTypes.NameIdentifier ).Value );
            }
            return null;
        }
    }


    private readonly ILogger<RecipesController> _logger;
    private readonly IRecipeService _recipeService;

    public RecipesController( IRecipeService recipeService, ILogger<RecipesController> logger )
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    [HttpGet]
    [Route( "search" )]
    public async Task<IActionResult> GetAll( int start = 1, int end = 4 )
    {
        _logger.LogDebug( "Get all recipes request" );
        var recipes = await _recipeService.GetAllRecipes( start, end );
        return Ok( recipes.ConvertAll( input => input.ConvertToRecipeDto( UserId ) ) );
    }

    [HttpGet]
    [Route( "{recipeId:int}" )]
    public async Task<IActionResult> Get( int recipeId )
    {
        _logger.LogDebug( "Get current recipe with {Id}", recipeId );
        var recipe = await _recipeService.GetRecipe( recipeId );
        return Ok( recipe.ConvertToRecipeDto( UserId ) );
    }
    
    [Authorize]
    [HttpDelete]
    [Route( "{recipeId:int}" )]
    public async Task<IActionResult> Delete( int recipeId )
    {
        _logger.LogDebug( "Remove recipe with {Id}", recipeId );
        await _recipeService.RemoveRecipe( recipeId, UserId.GetValueOrDefault( Guid.Empty ) );
        return Ok();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Save( RecipeDto recipeDto )
    {
        _logger.LogDebug( "Save new recipe" );
        var recipeEntity = recipeDto.ConvertToRecipeEntity( UserId ?? throw new AuthenticationException() );
        var createdId = await _recipeService.SaveRecipe( recipeEntity );
        return Ok( new RecipeCreated
        {
            RecipeId = createdId
        } );
    }

    [HttpPut]
    [Authorize]
    [Route( "like/{recipeId:int}" )]
    public async Task<IActionResult> Like( int recipeId )
    {
        _logger.LogDebug( "Like request received" );
        var recipe = await _recipeService.HandleLike( recipeId, UserId!.Value );
        return Ok( recipe.ConvertToRecipeDto( UserId ) );
    }

    [HttpPut]
    [Authorize]
    [Route( "favorite/{recipeId:int}" )]
    public async Task<IActionResult> Favorite( int recipeId )
    {
        _logger.LogDebug( "Favorite request received" );
        var recipe = await _recipeService.HandleFavorite( recipeId, UserId!.Value );
        return Ok( recipe.ConvertToRecipeDto( UserId ) );
    }
    
    [HttpGet]
    [Route( "best-recipe" )]
    public async Task<IActionResult> BestRecipe( int recipeId )
    {
        _logger.LogDebug( "Best recipe request received" );
        var bestRecipe = await _recipeService.GetBestRecipe( Action.View );
        return Ok( bestRecipe.ConvertToRecipeDto( UserId ) );
    }
    
    [HttpGet]
    [Route( "search/{searchQuery}" )]
    public async Task<IActionResult> Search( string searchQuery, int start = 1, int end = 4 )
    {
        _logger.LogDebug( "Make search query: {Query}", searchQuery );
        var recipes = await _recipeService.GetRecipesBySearchQuery( searchQuery, start, end );
        return Ok( recipes.ConvertAll( x => x.ConvertToRecipeDto( UserId ) ) );
    }
}