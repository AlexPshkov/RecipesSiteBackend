using Microsoft.IdentityModel.Tokens;
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
        var ingredients = ingredientEntities.Where( entity => 
            !entity.Title.IsNullOrEmpty() &&
            !entity.Description.IsNullOrEmpty() ).ToList();

        foreach ( var ingredientEntity in ingredients )
        {
            if ( ingredientEntity.Title.Length > 450 ) ingredientEntity.Title = ingredientEntity.Title[..450];
            if ( ingredientEntity.Description.Length > 950 ) ingredientEntity.Description = ingredientEntity.Description[..950];
        }
        return ingredients;
    }
    
    private static List<StepEntity>  ValidateSteps( this IEnumerable<StepEntity> stepEntities )
    {
        var steps = stepEntities.Where( entity => !entity.Description.IsNullOrEmpty() ).ToList();
        
        foreach ( var stepEntity in steps )
        {
            if ( stepEntity.Description.Length > 450 ) stepEntity.Description = stepEntity.Description[..450];
        }
        return steps;
    }

    private static List<TagEntity>  ValidateTags( this IEnumerable<TagEntity> tagEntities )
    {
        var tags = tagEntities.Where( entity => !entity.Name.IsNullOrEmpty() ).ToList();
        
        foreach ( var tagEntity in tags )
        {
            if ( tagEntity.Name.Length > 450 ) tagEntity.Name = tagEntity.Name[..450];
        }
        return tags;
    }
}