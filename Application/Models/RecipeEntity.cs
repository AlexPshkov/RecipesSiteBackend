using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Validators;

namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class RecipeEntity : AbstractEntity
{
    public int RecipeId { get; init; }

    private string _recipeName = "";
    public string RecipeName
    {
        get => _recipeName;
        set => _recipeName = RecipesValidators.ValidateName( value );
    }
    
    private string _recipeDescription = "";
    public string RecipeDescription
    {
        get => _recipeDescription;
        set => _recipeDescription = RecipesValidators.ValidateDescription( value );
    }
    
    private string _imagePath = "";
    public string ImagePath
    {
        get => _imagePath;
        set => _imagePath = RecipesValidators.ValidateImagePath( value );
    }
    
    private string _requiredTime = "";
    public string RequiredTime
    {
        get => _requiredTime;
        set => _requiredTime = RecipesValidators.ValidateRequiredTime( value );
    }
    
    private string _servingsAmount = "";
    public string ServingsAmount
    {
        get => _servingsAmount;
        set => _servingsAmount = RecipesValidators.ValidateServingsAmount( value );
    }
    
    public Guid UserId { get; init; }
    public UserEntity? User { get; init; }
    
    public List<FavoriteEntity> Favorites { get; init; } = new();
    public List<LikeEntity> Likes { get; init; } = new();
    
    public List<IngredientEntity> Ingredients { get; set; } = new();
    public List<StepEntity> Steps { get; set; } = new();
    public List<TagEntity> Tags { get; set; } = new();
    public List<RecipeActionEntity> Actions { get; } = new();
}

