namespace RecipesSiteBackend.Dto.Recipe;

public class IngredientDto
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}