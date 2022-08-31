using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Dto;

public static class RecipesDtoExtensions
{
    
    public static RecipeEntity ConvertToRecipeEntity( this RecipeDto dto )
    {
        return new RecipeEntity()
        {
            RecipeId = dto.id,
            RecipeName = dto.recipeName,
            RecipeDescription = dto.recipeDescription,
            ImageUrl = dto.imageURL,
            RequiredTime = dto.requiredTime,
            ServingsAmount = dto.servingsAmount,
            User = dto.user.ConvertToUserEntity(),
            Favorites = dto.favorites.ConvertAll( input => input.ConvertToFavoriteEntity() ),
            Likes = dto.likes.ConvertAll( input => input.ConvertToLikeEntity() ),
            Tags = dto.tags.ConvertAll( input => input.ConvertToTagEntity() ),
            Ingredients = dto.ingredients.ConvertAll( input => input.ConvertToIngredientEntity() ),
            Steps = dto.steps.ConvertAll( input => input.ConvertToStepEntity() )
        };
    }
    
    public static TagEntity ConvertToTagEntity( this TagDto dto )
    {
        return new TagEntity()
        {
            TagId = dto.id,
            Name = dto.tagName
        };
    }
    
    public static LikeEntity ConvertToLikeEntity( this LikeDto dto )
    {
        return new LikeEntity()
        {
            LikeId = dto.id,
            UserId = Guid.Parse( dto.userId ),
        };
    }
    
    public static FavoriteEntity ConvertToFavoriteEntity( this FavoriteDto dto )
    {
        return new FavoriteEntity()
        {
            FavoriteId = dto.id,
            UserId = Guid.Parse( dto.userId ),
        };
    }
    
    public static IngredientEntity ConvertToIngredientEntity( this IngredientDto dto )
    {
        return new IngredientEntity()
        {
            IngredientId = dto.id,
            Description = dto.description,
            RecipeId = dto.recipeId,
        };
    }

    public static StepEntity ConvertToStepEntity( this StepDto dto )
    {
        return new StepEntity()
        {
            StepId = dto.id,
            Description = dto.description,
            RecipeId = dto.recipeId,
        };
    }
}