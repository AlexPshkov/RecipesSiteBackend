using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Dto.Requests;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Extensions.Requests;
using RecipesSiteBackend.Filters;
using RecipesSiteBackend.Services;
using RecipesSiteBackend.Validators;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
[TypeFilter( typeof( ExceptionsFilter ) )]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;
    private readonly ISecurityService _securityService;

    public AuthController( ILogger<AuthController> logger, IUserService userService, ISecurityService securityService )
    {
        _logger = logger;
        _securityService = securityService;
        _userService = userService;
    }

    [HttpPost]
    [Route( "login" )]
    public async Task<IActionResult> Login( [FromBody] LoginRequest request )
    {
        _logger.LogInformation( "Login request from [{Login}] received", request.Login );
        var user = await _userService.GetUserByLogin( request.Login );
        if ( user == null || !_securityService.VerifyPassword( request.Password, user.Password ) )
        {
            throw new InvalidAuthException();
        }

        _logger.LogInformation( "Login [{Login}] success. Generate new token", request.Login );
        return Ok( new TokenDto
        {
            AccessToken = _securityService.GetToken( user )
        } );
    }

    [HttpPost]
    [Route( "register" )]
    public async Task<IActionResult> Register( [FromBody] RegisterRequest request )
    {
        _logger.LogInformation( "Register request from [{Login}] received", request.Login );
        var user = request.ConvertToUserEntity().ValidateUser();
        if ( await _userService.GetUserByLogin( user.Login ) != null )
        {
            throw new UserAlreadyExistsException( user.Login );
        }

        await _userService.Save( user );

        _logger.LogInformation( "Register [{Login}] success. Generate new token", request.Login );
        return Ok( new TokenDto
        {
            AccessToken = _securityService.GetToken( user )
        } );
    }
}