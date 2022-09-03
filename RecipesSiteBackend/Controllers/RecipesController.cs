using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Services;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class RecipesController : Controller
{
    private Guid UserId => Guid.Parse( User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value );

    private readonly ILogger<RecipesController> _logger;
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
    {
        _logger = logger;
        _recipeService = recipeService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogDebug( "Get all recipes request" );
        return Ok(_recipeService.GetAllRecipes());
    }
    
    [Route("{recipeId:int}")]
    [HttpGet]
    public IActionResult Get(int recipeId)
    {
        _logger.LogDebug( "Get current recipe with {Id}", recipeId );
        try
        {
            return Ok( _recipeService.GetRecipe( recipeId ) );
        }
        catch ( NoSuchRecipeException exception )
        {
            return NotFound( exception.Message );
        }
    }

    [Route("like/{recipeId:int}")]
    [Authorize]
    [HttpPut]
    public IActionResult Like(int recipeId)
    {
        _logger.LogDebug( "Like request received" );
        try
        {
            return Ok( _recipeService.HandleLike( recipeId, UserId ) );
        }
        catch ( NoSuchRecipeException exception )
        {
            return NotFound(exception.Message);
        }
    }
    
    [Route("favorite/{recipeId:int}")]
    [Authorize]
    [HttpPut]
    public IActionResult Favorite(int recipeId)
    {
        _logger.LogDebug( "Favorite request received" );
        try
        {
            return Ok( _recipeService.HandleFavorite( recipeId, UserId ) );
        }
        catch ( NoSuchRecipeException exception )
        {
            return NotFound(exception.Message);
        }
    }
    
}