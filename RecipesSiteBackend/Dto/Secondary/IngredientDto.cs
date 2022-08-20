namespace RecipesSiteBackend.Dto.Secondary;

public class IngredientDto
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public RecipeDto recipe { get; set; }
}