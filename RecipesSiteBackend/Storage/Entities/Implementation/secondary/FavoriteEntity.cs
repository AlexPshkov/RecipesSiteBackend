using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class FavoriteEntity : AbstractEntity
{
    [Key]
    public int FavoriteId { get; set; }
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
    public int RecipeId { get; set; }
    public RecipeEntity Recipe { get; set; }
}
