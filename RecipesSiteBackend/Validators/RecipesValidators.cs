using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Validators;

public static class RecipesValidators
{

    public static RecipeEntity ValidateRecipe( this RecipeEntity recipeEntity )
    {
        if ( recipeEntity.RecipeName.IsNullOrEmpty() ) throw new InvalidRecipeException( "RecipeName is empty", recipeEntity );
        if ( recipeEntity.RecipeDescription.IsNullOrEmpty() ) throw new InvalidRecipeException( "RecipeDescription is empty", recipeEntity );

        recipeEntity.Ingredients = recipeEntity.Ingredients.ValidateIngredients();
        recipeEntity.Steps = recipeEntity.Steps.ValidateSteps();
        recipeEntity.Tags = recipeEntity.Tags.ValidateTags();
        
        return recipeEntity;
    }

    private static List<IngredientEntity>  ValidateIngredients( this IEnumerable<IngredientEntity> ingredientEntities )
    {
        return ingredientEntities.Where( entity => 
            !entity.Title.IsNullOrEmpty() &&
            !entity.Description.IsNullOrEmpty() ).ToList();
    }
    
    private static List<StepEntity>  ValidateSteps( this IEnumerable<StepEntity> stepEntities )
    {
        return stepEntities.Where( entity => !entity.Description.IsNullOrEmpty() ).ToList();
    }

    private static List<TagEntity>  ValidateTags( this IEnumerable<TagEntity> tagEntities )
    {
        return tagEntities.Where( entity => !entity.Name.IsNullOrEmpty() ).ToList();
    }
}