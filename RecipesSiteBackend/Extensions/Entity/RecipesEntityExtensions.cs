﻿using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Entity;

public static class RecipesEntityExtensions
{
    
    public static RecipeDto ConvertToRecipeDto( this RecipeEntity?  recipeEntity )
    {
        if ( recipeEntity == null )
        {
            return new RecipeDto();
        }
        return new RecipeDto
        {
            Id = recipeEntity.RecipeId,
            RecipeName = recipeEntity.RecipeName,
            RecipeDescription = recipeEntity.RecipeDescription,
            ImagePath = recipeEntity.ImagePath,
            RequiredTime = recipeEntity.RequiredTime,
            ServingsAmount = recipeEntity.ServingsAmount,
            UserLogin = recipeEntity.User.Login,
            FavoritesAmount = recipeEntity.Favorites.Count,
            LikesAmount = recipeEntity.Likes.Count,
            Tags = recipeEntity.Tags.ConvertAll( input => input.ConvertToTagDto()),
            Ingredients = recipeEntity.Ingredients.ConvertAll( input => input.ConvertToIngredientDto() ),
            Steps = recipeEntity.Steps.ConvertAll( input => input.ConvertToStepDto() ),
        };
    } 
    
    public static FavoriteDto ConvertToFavoriteDto( this FavoriteEntity ?  favoriteEntity )
    {
        if ( favoriteEntity == null )
        {
            return new FavoriteDto();
        }
        return new FavoriteDto
        {
            Id = favoriteEntity.FavoriteId,
            UserId = favoriteEntity.User.UserId.ToString(),
            RecipeId = favoriteEntity.RecipeId
        };
    } 
    
    public static LikeDto ConvertToLikeDto( this LikeEntity ?  likeEntity )
    {
        if ( likeEntity == null )
        {
            return new LikeDto();
        }
        return new LikeDto
        {
            Id = likeEntity.LikeId,
            UserId = likeEntity.User.UserId.ToString(),
            RecipeId = likeEntity.RecipeId
        };
    }
    
    public static IngredientDto ConvertToIngredientDto( this IngredientEntity ?  ingredientEntity )
    {
        if ( ingredientEntity == null )
        {
            return new IngredientDto();
        }
        return new IngredientDto
        {
            Id = ingredientEntity.IngredientId,
            Title = ingredientEntity.Title,
            Description = ingredientEntity.Description,
        };
    } 
    
    public static StepDto ConvertToStepDto( this StepEntity ?  stepEntity )
    {
        if ( stepEntity == null )
        {
            return new StepDto();
        }
        return new StepDto
        {
            Id = stepEntity.StepId,
            Description = stepEntity.Description
        };
    } 
    
    public static TagDto ConvertToTagDto( this TagEntity ?  tagEntity )
    {
        if ( tagEntity == null )
        {
            return new TagDto();
        }
        return new TagDto
        {
            Id = tagEntity.TagId,
            TagName = tagEntity.Name
        };
    } 
}
