using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Entity;

public static class RecipesEntityExtensions
{
    
    public static RecipeDto ConvertToRecipeDto( this RecipeEntity?  recipeEntity )
    {
        if ( recipeEntity == null ) return new RecipeDto();
        return new RecipeDto
        {
            Id = recipeEntity.RecipeId,
            RecipeName = recipeEntity.RecipeName,
            RecipeDescription = recipeEntity.RecipeDescription,
            ImagePath = recipeEntity.ImagePath,
            RequiredTime = recipeEntity.RequiredTime,
            ServingsAmount = recipeEntity.ServingsAmount,
            User = recipeEntity.User.ConvertToUserDto(),
            Favorites = recipeEntity.Favorites.ConvertAll( input => input.ConvertToFavoriteDto()),
            Likes = recipeEntity.Likes.ConvertAll( input => input.ConvertToLikeDto()),
            Tags = recipeEntity.Tags.ConvertAll( input => input.ConvertToTagDto())
        };
    } 
    
    public static FavoriteDto ConvertToFavoriteDto( this FavoriteEntity ?  favoriteEntity )
    {
        if ( favoriteEntity == null ) return new FavoriteDto();
        return new FavoriteDto
        {
            Id = favoriteEntity.FavoriteId,
            UserId = favoriteEntity.User.UserId.ToString(),
            RecipeId = favoriteEntity.RecipeId
        };
    } 
    
    public static LikeDto ConvertToLikeDto( this LikeEntity ?  likeEntity )
    {
        if ( likeEntity == null ) return new LikeDto();
        return new LikeDto
        {
            Id = likeEntity.LikeId,
            UserId = likeEntity.User.UserId.ToString(),
            RecipeId = likeEntity.RecipeId
        };
    }
    
    public static IngredientDto ConvertToIngredientDto( this IngredientEntity ?  ingredientEntity )
    {
        if ( ingredientEntity == null ) return new IngredientDto();
        return new IngredientDto
        {
            Id = ingredientEntity.IngredientId,
            Title = ingredientEntity.Title,
            Description = ingredientEntity.Description,
            RecipeId = ingredientEntity.RecipeId
        };
    } 
    
    public static StepDto ConvertToStepDto( this StepEntity ?  stepEntity )
    {
        if ( stepEntity == null ) return new StepDto();
        return new StepDto
        {
            Id = stepEntity.StepId,
            Description = stepEntity.Description,
            RecipeId = stepEntity.RecipeId
        };
    } 
    
    public static TagDto ConvertToTagDto( this TagEntity ?  tagEntity )
    {
        if ( tagEntity == null ) return new TagDto();
        return new TagDto
        {
            Id = tagEntity.TagId,
            TagName = tagEntity.Name
        };
    } 
}
