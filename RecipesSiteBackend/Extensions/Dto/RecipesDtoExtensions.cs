using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Dto;

public static class RecipesDtoExtensions
{
    
    public static RecipeEntity ConvertToRecipeEntity( this RecipeDto dto )
    {
        return new RecipeEntity
        {
            RecipeId = dto.Id,
            RecipeName = dto.RecipeName,
            RecipeDescription = dto.RecipeDescription,
            ImagePath = dto.ImagePath,
            RequiredTime = dto.RequiredTime,
            ServingsAmount = dto.ServingsAmount,
            User = dto.User.ConvertToUserEntity(),
            Favorites = dto.Favorites.ConvertAll( input => input.ConvertToFavoriteEntity() ),
            Likes = dto.Likes.ConvertAll( input => input.ConvertToLikeEntity() ),
            Tags = dto.Tags.ConvertAll( input => input.ConvertToTagEntity() ),
            Ingredients = dto.Ingredients.ConvertAll( input => input.ConvertToIngredientEntity() ),
            Steps = dto.Steps.ConvertAll( input => input.ConvertToStepEntity() )
        };
    }
    
    public static TagEntity ConvertToTagEntity( this TagDto dto )
    {
        return new TagEntity
        {
            TagId = dto.Id,
            Name = dto.TagName
        };
    }
    
    public static LikeEntity ConvertToLikeEntity( this LikeDto dto )
    {
        return new LikeEntity
        {
            LikeId = dto.Id,
            UserId = Guid.Parse( dto.UserId ),
        };
    }
    
    public static FavoriteEntity ConvertToFavoriteEntity( this FavoriteDto dto )
    {
        return new FavoriteEntity
        {
            FavoriteId = dto.Id,
            UserId = Guid.Parse( dto.UserId ),
        };
    }
    
    public static IngredientEntity ConvertToIngredientEntity( this IngredientDto dto )
    {
        return new IngredientEntity
        {
            IngredientId = dto.Id,
            Description = dto.Description,
            RecipeId = dto.RecipeId,
        };
    }

    public static StepEntity ConvertToStepEntity( this StepDto dto )
    {
        return new StepEntity
        {
            StepId = dto.Id,
            Description = dto.Description,
            RecipeId = dto.RecipeId,
        };
    }
}