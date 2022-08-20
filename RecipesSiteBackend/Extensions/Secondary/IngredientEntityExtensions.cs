using RecipesSiteBackend.Dto.Secondary;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Secondary;

public static class IngredientEntityExtensions
{
    
    public static IngredientDto ConvertToIngredientDto( this IngredientEntity ?  ingredientEntity )
    {
        if ( ingredientEntity == null ) return new IngredientDto();
        return new IngredientDto()
        {
            id = ingredientEntity.Id,
            title = ingredientEntity.Title,
            description = ingredientEntity.Description
        };
    } 
}