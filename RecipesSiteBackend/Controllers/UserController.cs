using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Dto.Requests;
using RecipesSiteBackend.Extensions.Dto;
using RecipesSiteBackend.Extensions.Entity;
using RecipesSiteBackend.Extensions.Requests;
using RecipesSiteBackend.Services;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
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
    public IActionResult GetUser()
    {
        _logger.LogDebug( "Get own user object request" );
        var userEntity = _userService.GetUserById( UserId );
        return Ok( userEntity.ConvertToUserDto() );
    }
    
    [HttpGet]
    [Authorize]
    [Route( "favorites" )]
    public IActionResult GetFavorites()
    {
        _logger.LogDebug( "Get favorites recipes request" );
        return Ok( _userService.GetFavorites( UserId ).ConvertAll( input => input.ConvertToRecipeDto( UserId ) ) );
    }
    
    [HttpGet]
    [Authorize]
    [Route( "likes" )]
    public IActionResult GetLikes()
    {
        _logger.LogDebug( "Get liked recipes request" );
        return Ok( _userService.GetLikes( UserId ).ConvertAll( input => input.ConvertToRecipeDto( UserId ) ) );
    }
    
    [HttpGet]
    [Authorize]
    [Route( "created" )]
    public IActionResult GetCreated()
    {
        _logger.LogDebug( "Get created recipes request" );
        return Ok( _userService.GetCreatedRecipes( UserId ).ConvertAll( input => input.ConvertToRecipeDto( UserId ) ) );
    }
    
    [HttpGet]
    [Authorize]
    [Route( "statistic" )]
    public IActionResult GetStatistic()
    {
        _logger.LogDebug( "Get user statistic request" );
        var userEntity = _userService.GetFullUserById( UserId );
        return Ok( userEntity.ConvertToUserStatisticDto() );
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult Save( ChangeUserDataRequest changeUserData )
    {
        _logger.LogDebug( "Save new user" );
        var userEntity = changeUserData.ConvertToUserEntity( UserId );
        _userService.Save( userEntity );
        _logger.LogDebug( "Register: New token for {Login}", userEntity.Login );
        return Ok(new TokenDto
        {
            AccessToken = _securityService.GetToken( userEntity )
        });
    }
}