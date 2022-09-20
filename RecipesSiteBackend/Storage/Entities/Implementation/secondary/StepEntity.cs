namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class StepEntity : AbstractEntity
{
    public int StepId { get; init; }
    public string Description { get; init; }
    public int RecipeId { get; init; }
    
    public RecipeEntity? Recipe { get; init; }
}
