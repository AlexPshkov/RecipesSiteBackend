﻿using System.Security.Claims;
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

[Authorize]
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
    public async Task<IActionResult> GetUser()
    {
        var userId = UserId;
        _logger.LogInformation( "Trying to get user data with ID: {UserId}", userId );
       
        var userEntity = await _userService.GetUserById( userId );
        if ( userEntity == null )
        {
            throw new InvalidAuthException();
        }
        _logger.LogInformation( "Success! Data of user with ID:  {UserId} got", userId );
        
        return Ok( userEntity.ConvertToUserDto() );
    }
    
    [HttpGet]
    [Route( "favorites" )]
    public async Task<IActionResult> GetFavorites( int start = 1, int end = 4 )
    {
        var userId = UserId;
        _logger.LogInformation( "Trying to get favorite recipes from user with ID: {UserId}", userId );
        
        var favorites = await _userService.GetFavorites( userId, start, end );
        _logger.LogInformation( "Success! Favorites of user with ID:  {UserId} got", userId );
        
        return Ok( favorites.ConvertAll( input => input.ConvertToRecipeDto( userId ) ) );
    }
    
    [HttpGet]
    [Route( "created" )]
    public async Task<IActionResult> GetCreated( int start = 1, int end = 4 )
    {
        var userId = UserId;
        _logger.LogInformation( "Trying to get created recipes from user with ID: {UserId}", userId );
        
        var created = await _userService.GetCreatedRecipes( userId, start, end );
        _logger.LogInformation( "Success! Created recipes of user with ID: {UserId} got", userId );
        
        return Ok( created.ConvertAll( input => input.ConvertToRecipeDto( userId ) ) );
    }
    
    [HttpGet]
    [Route( "statistic" )]
    public async Task<IActionResult> GetStatistic()
    {
        var userId = UserId;
        _logger.LogInformation( "Trying to get statistic from user with ID: {UserId}", userId );
        
        var userStatistic = await _userService.GetUserStatistic( userId );
        _logger.LogInformation( "Success! Statistic of user with ID: {UserId} got", userId );
        
        return Ok( userStatistic.ConvertToUserStatisticDto() );
    }
    
    [HttpPost]
    public async Task<IActionResult> Save( ChangeUserDataRequest changeUserData )
    {
        var userId = UserId;
        _logger.LogInformation( "Trying to change user data from user with ID: {UserId}", userId );
        
        var userEntity = changeUserData.ConvertToUserEntity( userId );
        await _userService.Save( userEntity );
        _logger.LogInformation( "Success! New data for user with ID: {UserId} successfully saved", userId );
        
        return Ok(new TokenDto
        {
            AccessToken = _securityService.GetToken( userEntity )
        });
    }
}