namespace RecipesSiteBackend.Dto.Recipe;

public class StepDto
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string Description { get; set; }
}