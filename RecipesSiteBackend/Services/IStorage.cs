using RecipesSiteBackend.Dto;

namespace RecipesSiteBackend.Services;

public interface IStorage
{

    List<TagDto> getTags();
    List<RecipeDto> getRecipes();
}