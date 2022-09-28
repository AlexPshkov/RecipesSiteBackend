using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto.Responses;
using RecipesSiteBackend.Filters;
using RecipesSiteBackend.Services;

namespace RecipesSiteBackend.Controllers;

[Authorize]
[ApiController]
[Route( "api/[controller]" )]
[TypeFilter( typeof( ExceptionsFilter ) )]
public class ImagesController : Controller
{
    private Guid UserId => Guid.Parse( User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value );
    
    private readonly ILogger<ImagesController> _logger;
    private readonly IImageService _imageService;

    public ImagesController( ILogger<ImagesController> logger, IImageService imageService )
    {
        _logger = logger;
        _imageService = imageService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Save( IFormFile formFile )
    {
        var userId = UserId;
        _logger.LogInformation( "Saving new image file {Name}. Sender UserID: {UserId}", formFile.Name, userId );
        
        var imagePath = await _imageService.SaveImage( formFile, userId );
        
        _logger.LogInformation( "Success! Image {Name} from UserID: {UserId} successfully saved. Image path: {ImagePath}", formFile.Name, userId, imagePath );
        return Ok( new ImageLoaded
        {
            ImagePath = imagePath
        } );
    }
}