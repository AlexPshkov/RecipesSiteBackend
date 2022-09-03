using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Extensions.Requests;
using RecipesSiteBackend.Requests;
using RecipesSiteBackend.Services;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class AuthController : ControllerBase
{
    
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    
    public AuthController( ILogger<AuthController> logger, IUserService userService, ITokenService tokenService )
    {
        _logger = logger;
        _tokenService = tokenService;
        _userService = userService;
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login( [FromBody] LoginRequest request )
    {
        var user = _userService.GetByLoginAndPassword( request.Login, request.Password );
        if ( user == null )
        {
            return Unauthorized();
        }
        
        _logger.LogDebug( "Login: New token for {Login}", user.Login );
        return Ok(new TokenDto
        {
            AccessToken = _tokenService.GetToken( user )
        });
    }
    
    [Route("register")]
    [HttpPost]
    public IActionResult Register( [FromBody] RegisterRequest request )
    {
        var user = request.ConvertToUserEntity();
        if ( _userService.GetUserByLogin( user.Login ) != null )
        {
            return Conflict("User with same login already exists");
        }
        _userService.Save( user );
        
        _logger.LogDebug( "Register: New token for {Login}", user.Login );
        return Ok(new TokenDto
        {
            AccessToken = _tokenService.GetToken( user )
        });
    }
} 



