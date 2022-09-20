namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class RecipeActionEntity : AbstractEntity
{
    public int ActionDay { get; init; }

    public int ActionId { get; init; }
    public Action? Action { get; init; }

    public int RecipeId { get; init; }
    public RecipeEntity? Recipe { get; init; }
    
    public Guid UserId { get; init; }
    public UserEntity? User { get; init; }
}

public enum Action
{
    Favorite,
    Like, 
    View
}
