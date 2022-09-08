namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class TagEntity : AbstractEntity
{
    public int TagId { get; set; }
    public string Name { get; set; }
    
    public List<RecipeEntity> Recipes { get; set; }
}
