namespace RecipesSiteBackend.Services;

public interface IImageService
{
    public Task<string> SaveImage( IFormFile formFile, Guid userId );
}