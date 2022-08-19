using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class IngredientEntity : AbstractEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required] 
    [MaxLength(500)]
    public string Title { get; set; }
    
    [Required] 
    [MaxLength(1000)]
    public string Description { get; set; }

    public RecipeEntity Recipe { get; set; }
}
