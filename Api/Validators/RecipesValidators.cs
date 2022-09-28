using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Validators;

public static class RecipesValidators
{
    public static RecipeEntity ValidateRecipe( this RecipeEntity recipeEntity )
    {
        ValidateName( recipeEntity.RecipeName );
        ValidateDescription( recipeEntity.RecipeDescription );
        ValidateServingsAmount( recipeEntity.ServingsAmount );
        ValidateRequiredTime( recipeEntity.RequiredTime );
        ValidateImagePath( recipeEntity.ImagePath );
        
        recipeEntity.Ingredients.ValidateIngredients();
        recipeEntity.Steps.ValidateSteps();
        recipeEntity.Tags.ValidateTags();

        return recipeEntity;
    }

    public static string ValidateName( string recipeName )
    {
        if ( recipeName.IsNullOrEmpty() ) throw new InvalidParamException( "RecipeName is empty" );
        if ( recipeName.Length > 150 ) throw new InvalidParamException( "Recipe name is too big" );

        return recipeName;
    }

    public static string ValidateDescription( string recipeDescription )
    {
        if ( recipeDescription.IsNullOrEmpty() ) throw new InvalidParamException( "RecipeDescription is empty" );
        if ( recipeDescription.Length > 150 ) throw new InvalidParamException( "Recipe description is too big" );

        return recipeDescription;
    }

    public static string ValidateServingsAmount( string servingsAmount )
    {
        if ( servingsAmount.Length > 50 ) throw new InvalidParamException( "Recipe servings amount is too big" );

        return servingsAmount;
    }

    public static string ValidateRequiredTime( string requiredTime )
    {
        if ( requiredTime.Length > 50 ) throw new InvalidParamException( "Recipe required time is too big" );

        return requiredTime;
    }

    public static string ValidateImagePath( string imagePath )
    {
        if ( imagePath.Length > 550 ) throw new InvalidParamException( "Recipe image path is too big" );

        return imagePath;
    }

    private static List<IngredientEntity> ValidateIngredients( this IEnumerable<IngredientEntity> ingredientEntities )
    {
        var ingredients = ingredientEntities.Where( entity =>
            !entity.Title.IsNullOrEmpty() &&
            !entity.Description.IsNullOrEmpty() ).ToList();

        foreach ( var ingredientEntity in ingredients )
        {
            if ( ingredientEntity.Title.Length > 450 ) throw new InvalidParamException( "Ingredient title is too big" );
            if ( ingredientEntity.Description.Length > 950 ) throw new InvalidParamException( "Ingredient description is too big" );
        }

        return ingredients;
    }

    private static List<StepEntity> ValidateSteps( this IEnumerable<StepEntity> stepEntities )
    {
        var steps = stepEntities.Where( entity => !entity.Description.IsNullOrEmpty() ).ToList();

        foreach ( var stepEntity in steps )
        {
            if ( stepEntity.Description.Length > 450 ) throw new InvalidParamException( "Step description is too big" );
        }

        return steps;
    }

    private static List<TagEntity> ValidateTags( this IEnumerable<TagEntity> tagEntities )
    {
        var tags = tagEntities.Where( entity => !entity.Name.IsNullOrEmpty() ).ToList();

        foreach ( var tagEntity in tags )
        {
            if ( tagEntity.Name.Length > 450 ) throw new InvalidParamException( "Tag name is too big" );
        }

        return tags;
    }
}