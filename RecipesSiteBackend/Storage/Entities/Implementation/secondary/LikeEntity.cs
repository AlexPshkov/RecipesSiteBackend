using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class LikeEntity : AbstractEntity
{
    [Key]
    public int Id { get; set; }
    
    public UserEntity User { get; set; }
    
    public RecipeEntity Recipe { get; set; }
}
