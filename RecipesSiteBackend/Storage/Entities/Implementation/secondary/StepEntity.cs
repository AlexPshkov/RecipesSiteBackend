using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class StepEntity : AbstractEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required] 
    [MaxLength(1000)]
    public string Description { get; set; }
    
    public RecipeEntity Recipe { get; set; }
}
