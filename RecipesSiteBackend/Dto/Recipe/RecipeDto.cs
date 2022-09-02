namespace RecipesSiteBackend.Dto.Recipe;

public class RecipeDto
{
    public int Id { get; set; }
    public string RecipeName { get; set; }
    public string RecipeDescription { get; set; }

    public string ImagePath { get; set; }
    public string RequiredTime { get; set; }
    public string ServingsAmount { get; set; }

    public UserDto User { get; set; }
    public List<FavoriteDto> Favorites { get; set; }
    public List<LikeDto> Likes { get; set; }
    public List<TagDto> Tags { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
    public List<StepDto> Steps { get; set; }
}