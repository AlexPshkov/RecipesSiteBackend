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
    
    public List<FavoriteEntity> Favorites { get; set; } = new();
    public List<IngredientEntity> Ingredients { get; set; } = new();
    public List<StepEntity> Steps { get; set; } = new();
    public List<LikeEntity> Likes { get; set; } = new();
    public List<TagEntity> Tags { get; set; } = new();
    public List<RecipeActionEntity> Actions { get; set; } = new();
}

