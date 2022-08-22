namespace RecipesSiteBackend.Dto.Recipe;

public class IngredientDto
{
    public int id { get; set; }
    public int recipeId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
}