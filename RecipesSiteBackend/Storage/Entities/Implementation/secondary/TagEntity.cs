using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Storage.Entities.Implementation.secondary;

public class TagEntity : AbstractEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required] 
    [MaxLength(500)]
    public string Name { get; set; }
    
    [Required] 
    [MaxLength(500)]
    public string IconUrl { get; set; }
    
    [Required] 
    [MaxLength(1000)]
    public string Description { get; set; }
}
