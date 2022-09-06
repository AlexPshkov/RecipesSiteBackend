namespace RecipesSiteBackend.Dto.Recipe;

public class RecipeDto
{
    public int Id { get; set; }
    public string RecipeName { get; set; }
    public string RecipeDescription { get; set; }

    public string ImagePath { get; set; }
    public string RequiredTime { get; set; }
    public string ServingsAmount { get; set; }
    
    public string UserLogin { get; set; } = "";
    public int FavoritesAmount { get; set; }
    public int LikesAmount { get; set; }
    public bool IsLiked { get; set; }
    public bool IsFavorite { get; set; }
    public List<TagDto> Tags { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
    public List<StepDto> Steps { get; set; }
}