using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Extensions.Secondary;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions;

public static class RecipeEntityExtensions
{
    
    public static RecipeDto ConvertToRecipeDto( this RecipeEntity ?  recipeEntity )
    {
        if ( recipeEntity == null ) return new RecipeDto();
        return new RecipeDto()
        {
            id = recipeEntity.Id,
            recipeName = recipeEntity.RecipeName,
            recipeDescription = recipeEntity.RecipeDescription,
            imageURL = recipeEntity.ImageUrl,
            requiredTime = recipeEntity.RequiredTime,
            servingsAmount = recipeEntity.ServingsAmount,
            author = recipeEntity.Author.ConvertToUserDto(),
            favorites = recipeEntity.Favorites.ConvertAll( input => input.ConvertToFavoriteDto()),
            likes = recipeEntity.Likes.ConvertAll( input => input.ConvertToLikeDto()),
            tags = recipeEntity.Tags.ConvertAll( input => input.ConvertToTagDto())
        };
    } 
}
