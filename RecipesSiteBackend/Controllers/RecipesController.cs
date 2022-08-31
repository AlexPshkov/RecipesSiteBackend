using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Extensions.Entity;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class RecipesController : Controller
{
    private Guid UserId => Guid.Parse( User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value );

    private readonly ILogger<RecipesController> _logger;
    private readonly IRecipeRepository _repository;

    public RecipesController(IRecipeRepository repository,  ILogger<RecipesController> logger)
    {
        _logger = logger;
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation( "Get all recipes request" );
        return Ok(_repository.GetAll().ConvertAll( input => input.ConvertToRecipeDto() ));
    }
    
    [Route("{recipeId:int}")]
    [HttpGet]
    public IActionResult Get(int recipeId)
    {
        _logger.LogInformation( "Get current recipe with {Id}", recipeId );
        return Ok(_repository.GetById( recipeId ).ConvertToRecipeDto());
    }
    
    [Route("favorites")]
    [Authorize]
    [HttpGet]
    public IActionResult GetFavorites()
    {
        _logger.LogInformation( "Get favorites recipes request" );
        return Ok(_repository.GetUserFavorites( UserId ).ConvertAll( input => input.ConvertToRecipeDto() ));
    }
    
    [Route("like/{recipeId:int}")]
    [Authorize]
    [HttpPut]
    public IActionResult Like(int recipeId)
    {
        _logger.LogInformation( "Like request received" );

        
        var recipe = _repository.GetById( recipeId );
        if ( recipe == null ) return Conflict();
        
        var userId = UserId;
        var domainLike = recipe.Likes.Find( input => input.UserId.Equals( userId ) );


        var likeEntity = new LikeEntity()
        {
            LikeId = domainLike?.LikeId ?? 0,
            Recipe = recipe,
            UserId = userId
        };

        if ( domainLike != null ) recipe.Likes.Remove( domainLike );
        else recipe.Likes.Add(likeEntity );
        _repository.Save();
        
        return Ok( recipe.ConvertToRecipeDto() );
    }
    
    [Route("favorite/{recipeId:int}")]
    [Authorize]
    [HttpPut]
    public IActionResult Favorite(int recipeId)
    {
        _logger.LogInformation( "Favorite request received" );

        
        var recipe = _repository.GetById( recipeId );
        if ( recipe == null ) return Conflict();
        
        var userId = UserId;
        var domainFavorite = recipe.Favorites.Find( input => input.UserId.Equals( userId ) );


        var favoriteEntity = new FavoriteEntity()
        {
            FavoriteId = domainFavorite?.FavoriteId ?? 0,
            Recipe = recipe,
            UserId = userId
        };

        if ( domainFavorite != null ) recipe.Favorites.Remove( domainFavorite );
        else recipe.Favorites.Add(favoriteEntity );
        _repository.Save();
        
        return Ok( recipe.ConvertToRecipeDto() );
    }
    
}