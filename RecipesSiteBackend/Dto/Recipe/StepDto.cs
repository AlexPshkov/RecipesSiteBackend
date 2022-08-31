namespace RecipesSiteBackend.Dto.Recipe;

public class StepDto
{
    public int id { get; set; }
    public int recipeId { get; set; }
    public string description { get; set; }
}