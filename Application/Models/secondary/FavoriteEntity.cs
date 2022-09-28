namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class FavoriteEntity : AbstractEntity
{
    public int FavoriteId { get; init; }
    public Guid UserId { get; init; }
    public int RecipeId { get; init; }
    
    public UserEntity? User { get; init; }
    public RecipeEntity? Recipe { get; init; }
}
