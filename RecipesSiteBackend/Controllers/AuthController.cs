using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Auth;
using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Extensions;
using RecipesSiteBackend.Requests;
using RecipesSiteBackend.Services;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class AuthController : ControllerBase
{
    private readonly AuthOptions _authOptions;
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;
    
    public AuthController( IOptions<AuthOptions> authOptions, ILogger<AuthController> logger, IUserService userService )
    {
        _authOptions = authOptions.Value;
        _logger = logger;
        _userService = userService;
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login( [FromBody] LoginRequest request )
    {
        _logger.LogInformation( "Try to auth" );
        _logger.LogInformation( "Login request for {RequestLogin}", request.login );
        var user = _userService.GetByLoginAndPassword( request.login, request.password );
        if ( user == null ) return Unauthorized();
        
        var token = GetTokenDto( user );
        _logger.LogInformation( "login {RequestLogin} ok. \nToken: {@Token}", request.login, token );
        return Ok(token);
    }
    
    [Route("register")]
    [HttpPost]
    public IActionResult Register( [FromBody] RegisterRequest request )
    {
        _logger.LogInformation( "Register request for {Name} with login {Login}",request.name, request.login );
        var user = request.ConvertToUserEntity();
        if ( _userService.GetUserByLogin( user.Login ) != null ) return Conflict("User with same login already exists");
        
        var token = GetTokenDto( user );
        _userService.Save( user );
        _logger.LogInformation( "Register {RequestLogin} ok. \nToken: {@Token}", request.login, token );
        return Ok(token);
    }

    private TokenDto GetTokenDto( UserEntity userEntity )
    {
        var credentials = new SigningCredentials( _authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256 );

        var claims = new List<Claim>
        {
            new( JwtRegisteredClaimNames.Name, userEntity.Login ),
            new( JwtRegisteredClaimNames.Sub, userEntity.Id.ToString() ),
            new ( "role", userEntity.Role.ToString())
        };

        var token = new JwtSecurityToken( 
            _authOptions.Issuer,
            _authOptions.Audience,
            claims,
            expires: DateTime.Now.AddSeconds( _authOptions.TokenLifetime ),
            signingCredentials: credentials );
        return new TokenDto
        {
            access_token = new JwtSecurityTokenHandler().WriteToken( token )
        };
    }
} 



