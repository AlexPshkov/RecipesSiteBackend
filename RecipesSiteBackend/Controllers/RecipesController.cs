using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Extensions;
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
    
    
    [Route("own")]
    [Authorize]
    [HttpGet]
    public IActionResult GetFavorites()
    {
        _logger.LogInformation( "Get favorites recipes request" );
        return Ok(_repository.GetUserRecipes( UserId ).ConvertAll( input => input.ConvertToRecipeDto() ));
    }
    

    
    
}