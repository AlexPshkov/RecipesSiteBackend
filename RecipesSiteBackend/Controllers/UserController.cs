using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Dto.Requests;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Extensions.Entity;
using RecipesSiteBackend.Extensions.Requests;
using RecipesSiteBackend.Filters;
using RecipesSiteBackend.Services;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
[TypeFilter( typeof( ExceptionsFilter ) )]
public class UserController : Controller
{
    private Guid UserId => Guid.Parse( User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value );
    
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly ISecurityService _securityService;

    public UserController(ILogger<UserController> logger, IUserService userService, ISecurityService securityService)
    {
        _logger = logger;
        _userService = userService;
        _securityService = securityService;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<OkObjectResult> GetUser()
    {
        _logger.LogDebug( "Get own user object request" );
        var userEntity = await _userService.GetUserById( UserId );
        if ( userEntity == null )
        {
            throw new InvalidAuthException();
        }
        return Ok( userEntity.ConvertToUserDto() );
    }
    
    [HttpGet]
    [Authorize]
    [Route( "favorites" )]
    public async Task<IActionResult> GetFavorites()
    {
        _logger.LogDebug( "Get favorites recipes request" );
        var favorites = await _userService.GetFavorites( UserId );
        return Ok( favorites.ConvertAll( input => input.ConvertToRecipeDto( UserId ) ) );
    }
    
    [HttpGet]
    [Authorize]
    [Route( "likes" )]
    public async Task<IActionResult> GetLikes()
    {
        _logger.LogDebug( "Get liked recipes request" );
        var likes = await _userService.GetLikes( UserId );
        return Ok( likes.ConvertAll( input => input.ConvertToRecipeDto( UserId ) ) );
    }
    
    [HttpGet]
    [Authorize]
    [Route( "created" )]
    public async Task<IActionResult> GetCreated()
    {
        _logger.LogDebug( "Get created recipes request" );
        var created = await _userService.GetCreatedRecipes( UserId );
        return Ok( created.ConvertAll( input => input.ConvertToRecipeDto( UserId ) ) );
    }
    
    [HttpGet]
    [Authorize]
    [Route( "statistic" )]
    public async Task<IActionResult> GetStatistic()
    {
        _logger.LogDebug( "Get user statistic request" );
        var userEntity = await _userService.GetFullUserById( UserId );
        return Ok( userEntity.ConvertToUserStatisticDto() );
    }
    
    [Authorize]
    [HttpPost]
    public async Task<OkObjectResult> Save( ChangeUserDataRequest changeUserData )
    {
        var userEntity = changeUserData.ConvertToUserEntity( UserId );
        await _userService.Save( userEntity );
        _logger.LogDebug( "Register: New token for {Login}", userEntity.Login );
        return Ok(new TokenDto
        {
            AccessToken = _securityService.GetToken( userEntity )
        });
    }
}