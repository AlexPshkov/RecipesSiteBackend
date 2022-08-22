namespace RecipesSiteBackend.Dto.Recipe;

public class LikeDto
{
    public int id { get; set; }
    public int recipeId { get; set; }
    public string userId { get; set; }
}