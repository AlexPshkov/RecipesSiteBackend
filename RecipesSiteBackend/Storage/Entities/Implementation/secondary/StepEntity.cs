using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class StepEntity : AbstractEntity
{
    [Key]
    public int StepId { get; set; }
    
    [Required] 
    [MaxLength(1000)]
    public string Description { get; set; }
    
    public int RecipeId { get; set; }
    public RecipeEntity Recipe { get; set; }
}
