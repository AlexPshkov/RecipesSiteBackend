using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions;

public static class RecipeEntityExtensions
{
    
    public static RecipeDto ConvertToRecipeDto( this RecipeEntity ?  recipeEntity )
    {
        if ( recipeEntity == null ) return new RecipeDto();
        return new RecipeDto()
        {
            id = recipeEntity.Id,
            authorName = recipeEntity.Author.UserName,
            recipeName = recipeEntity.RecipeName,
            recipeDescription = recipeEntity.RecipeDescription,
            imageURL = recipeEntity.ImageUrl,
            requiredTime = recipeEntity.RequiredTime,
            servingsAmount = recipeEntity.ServingsAmount,
            favoritesAmount = recipeEntity.Favorites.Count.ToString(),
            likesAmount = recipeEntity.Likes.Count.ToString(),
            currentTags = recipeEntity.Tags.ConvertAll( input => input.ConvertToTagDto())
        };
    } 
}