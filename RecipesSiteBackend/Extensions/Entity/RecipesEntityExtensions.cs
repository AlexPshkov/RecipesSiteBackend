using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Entity;

public static class RecipesEntityExtensions
{
    
    public static RecipeDto ConvertToRecipeDto( this RecipeEntity ?  recipeEntity )
    {
        if ( recipeEntity == null ) return new RecipeDto();
        return new RecipeDto()
        {
            id = recipeEntity.RecipeId,
            recipeName = recipeEntity.RecipeName,
            recipeDescription = recipeEntity.RecipeDescription,
            imageURL = recipeEntity.ImageUrl,
            requiredTime = recipeEntity.RequiredTime,
            servingsAmount = recipeEntity.ServingsAmount,
            user = recipeEntity.User.ConvertToUserDto(),
            favorites = recipeEntity.Favorites.ConvertAll( input => input.ConvertToFavoriteDto()),
            likes = recipeEntity.Likes.ConvertAll( input => input.ConvertToLikeDto()),
            tags = recipeEntity.Tags.ConvertAll( input => input.ConvertToTagDto())
        };
    } 
    
    public static FavoriteDto ConvertToFavoriteDto( this FavoriteEntity ?  favoriteEntity )
    {
        if ( favoriteEntity == null ) return new FavoriteDto();
        return new FavoriteDto()
        {
            id = favoriteEntity.FavoriteId,
            userId = favoriteEntity.User.UserId.ToString(),
            recipeId = favoriteEntity.RecipeId
        };
    } 
    
    public static LikeDto ConvertToLikeDto( this LikeEntity ?  likeEntity )
    {
        if ( likeEntity == null ) return new LikeDto();
        return new LikeDto()
        {
            id = likeEntity.LikeId,
            userId = likeEntity.User.UserId.ToString(),
            recipeId = likeEntity.RecipeId
        };
    }
    
    public static IngredientDto ConvertToIngredientDto( this IngredientEntity ?  ingredientEntity )
    {
        if ( ingredientEntity == null ) return new IngredientDto();
        return new IngredientDto()
        {
            id = ingredientEntity.IngredientId,
            title = ingredientEntity.Title,
            description = ingredientEntity.Description,
            recipeId = ingredientEntity.RecipeId
        };
    } 
    
    public static StepDto ConvertToStepDto( this StepEntity ?  stepEntity )
    {
        if ( stepEntity == null ) return new StepDto();
        return new StepDto()
        {
            id = stepEntity.StepId,
            description = stepEntity.Description,
            recipeId = stepEntity.RecipeId
        };
    } 
    
    public static TagDto ConvertToTagDto( this TagEntity ?  tagEntity )
    {
        if ( tagEntity == null ) return new TagDto();
        return new TagDto()
        {
            id = tagEntity.TagId,
            tagName = tagEntity.Name
        };
    } 
}
