﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Extensions.Entity;
using RecipesSiteBackend.Services;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Route( "api/[controller]" )]
public class UserController : Controller
{
    private Guid UserId => Guid.Parse( User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value );
    
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    [Route("{userLogin}")]
    [HttpGet]
    public IActionResult GetUser(string userLogin)
    {
        _logger.LogDebug( "Get some user object request" );
        var userEntity = _userService.GetUserByLogin( userLogin );
        return Ok(userEntity.ConvertToUserDto());
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult GetUser()
    {
        _logger.LogDebug( "Get own user object request" );
        var userEntity = _userService.GetUserById( UserId );
        return Ok(userEntity.ConvertToUserDto());
    }
    
    [HttpGet]
    [Authorize]
    [Route("favorites")]
    public IActionResult GetFavorites()
    {
        _logger.LogDebug( "Get favorites recipes request" );
        return Ok(_userService.GetFavorites( UserId ).ConvertAll( input => input.ConvertToRecipeDto( UserId ) ));
    }
    
}