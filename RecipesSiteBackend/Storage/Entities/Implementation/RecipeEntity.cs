using System.ComponentModel.DataAnnotations;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class RecipeEntity : AbstractEntity
{
 
    public int RecipeId { get; set; }
    public string RecipeName { get; set; }
    public string RecipeDescription { get; set; }
    public string ImagePath { get; set; }
    public string RequiredTime { get; set; }
    public string ServingsAmount { get; set; }
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
    public List<FavoriteEntity> Favorites { get; set; }
    public List<IngredientEntity> Ingredients { get; set; }
    public List<StepEntity> Steps { get; set; }
    public List<LikeEntity> Likes { get; set; }
    public List<TagEntity> Tags { get; set; }
}

