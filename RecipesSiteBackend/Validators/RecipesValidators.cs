using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Validators;

public static class RecipesValidators
{
    private const int MinStringLength = 3;
    
    public static RecipeEntity ValidateRecipe( this RecipeEntity recipeEntity )
    {
        if ( recipeEntity.RecipeName.IsNullOrEmpty() || recipeEntity.RecipeName.Length < MinStringLength ) throw new InvalidRecipeException( "RecipeName is empty", recipeEntity );
        if ( recipeEntity.RecipeDescription.IsNullOrEmpty() || recipeEntity.RecipeDescription.Length < MinStringLength ) throw new InvalidRecipeException( "RecipeDescription is empty", recipeEntity );

        recipeEntity.Ingredients = recipeEntity.Ingredients.ValidateIngredients();
        recipeEntity.Steps = recipeEntity.Steps.ValidateSteps();
        recipeEntity.Tags = recipeEntity.Tags.ValidateTags();
        
        return recipeEntity;
    }

    private static List<IngredientEntity>  ValidateIngredients( this IEnumerable<IngredientEntity> ingredientEntities )
    {
        return ingredientEntities.Where( entity => 
            !entity.Title.IsNullOrEmpty() &&
            entity.Title.Length >= MinStringLength &&
            !entity.Description.IsNullOrEmpty() &&
            entity.Description.Length >= MinStringLength ).ToList();
    }
    
    private static List<StepEntity>  ValidateSteps( this IEnumerable<StepEntity> stepEntities )
    {
        return stepEntities.Where( entity => !entity.Description.IsNullOrEmpty() &&
                                             entity.Description.Length >= MinStringLength ).ToList();
    }

    private static List<TagEntity>  ValidateTags( this IEnumerable<TagEntity> tagEntities )
    {
        return tagEntities.Where( entity => !entity.Name.IsNullOrEmpty() &&
                                            entity.Name.Length >= MinStringLength ).ToList();
    }
}