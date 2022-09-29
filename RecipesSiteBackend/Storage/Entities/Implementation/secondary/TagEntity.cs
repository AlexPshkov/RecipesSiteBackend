namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class TagEntity : AbstractEntity
{
    public int TagId { get; init; }
    public string Name { get; init; }

    public List<RecipeEntity> Recipes { get; } = new();
}
