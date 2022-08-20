namespace RecipesSiteBackend.Dto.Secondary;

public class StepDto
{
    public int id { get; set; }
    public string description { get; set; }
    public RecipeDto recipe { get; set; }
}