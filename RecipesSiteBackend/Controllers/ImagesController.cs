using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesSiteBackend.Dto.Responses;
using RecipesSiteBackend.Services;

namespace RecipesSiteBackend.Controllers;

[ApiController]
[Authorize]
[Route( "api/[controller]" )]
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
        _logger.LogDebug( "Input file {Name}", formFile.Name );
        var imagePath = await _imageService.SaveImage( formFile, UserId );
        return Ok( new ImageLoaded
        {
            ImagePath = imagePath
        } );
    }
}