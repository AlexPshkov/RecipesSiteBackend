namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class IngredientEntity : AbstractEntity
{
    public int IngredientId { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public int RecipeId { get; init; }
    
    public RecipeEntity? Recipe { get; init; }
}
