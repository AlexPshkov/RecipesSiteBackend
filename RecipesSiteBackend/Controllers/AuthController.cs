﻿using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Dto.Requests;
using RecipesSiteBackend.Extensions.Requests;
using RecipesSiteBackend.Services;
using RecipesSiteBackend.Validators;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
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

    [Route("login")]
    [HttpPost]
    public IActionResult Login( [FromBody] LoginRequest request )
    {
        var user = _userService.GetUserByLogin( request.Login );
        if ( user == null || !_securityService.VerifyPassword( request.Password, user.Password  ) )
        {
            return Unauthorized();
        }
        
        _logger.LogDebug( "Login: New token for {Login}", user.Login );
        return Ok(new TokenDto
        {
            AccessToken = _securityService.GetToken( user )
        });
    }
    
    [Route("register")]
    [HttpPost]
    public IActionResult Register( [FromBody] RegisterRequest request )
    {
        var user = request.ConvertToUserEntity().ValidateUser();
        if ( _userService.GetUserByLogin( user.Login ) != null )
        {
            return Conflict("User with same login already exists");
        }
        _userService.Save( user );
        
        _logger.LogDebug( "Register: New token for {Login}", user.Login );
        return Ok(new TokenDto
        {
            AccessToken = _securityService.GetToken( user )
        });
    }
} 



