namespace RecipesSiteBackend.Dto.Recipe;

public class RecipeDto
{
    public int id { get; set; }
    public string recipeName { get; set; }
    public string recipeDescription { get; set; }

    public string imageURL { get; set; }
    public string requiredTime { get; set; }
    public string servingsAmount { get; set; }

    public UserDto user { get; set; }
    public List<FavoriteDto> favorites { get; set; }
    public List<LikeDto> likes { get; set; }
    public List<TagDto> tags { get; set; }
    public List<IngredientDto> ingredients { get; set; }
    public List<StepDto> steps { get; set; }
}