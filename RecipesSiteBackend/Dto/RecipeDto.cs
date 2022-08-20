using RecipesSiteBackend.Dto.Secondary;

namespace RecipesSiteBackend.Dto;

public class RecipeDto
{
    public int id { get; set; }
    public string recipeName { get; set; }
    public string recipeDescription { get; set; }

    public string imageURL { get; set; }
    public string requiredTime { get; set; }
    public string servingsAmount { get; set; }

    public UserDto author { get; set; }
    public List<FavoriteDto> favorites { get; set; }
    public List<LikeDto> likes { get; set; }
    public List<TagDto> tags { get; set; }
}