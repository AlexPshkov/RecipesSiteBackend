using System.ComponentModel.DataAnnotations;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class RecipeEntity : AbstractEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(500)]
    public string RecipeName { get; set; }
    
    [MaxLength(1000)]
    public string RecipeDescription { get; set; }

    [Required]
    [MaxLength(1000)]
    public string ImageUrl { get; set; }

    [Required]
    [MaxLength(50)]
    public string RequiredTime { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string ServingsAmount { get; set; }
    
    public UserEntity Author { get; set; }

    public List<FavoriteEntity> Favorites { get; set; }
    public List<IngredientEntity> Ingredients { get; set; }
    public List<StepEntity> Steps { get; set; }
    public List<LikeEntity> Likes { get; set; }
    public List<TagEntity> Tags { get; set; }
}

