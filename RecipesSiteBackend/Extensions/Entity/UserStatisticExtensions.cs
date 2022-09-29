using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Exceptions.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Extensions.Entity;

public static class UserStatisticExtensions
{
    /**
     * <exception cref="NoSuchUserException"></exception>
     */
    public static UserStatisticDto ConvertToUserStatisticDto( this UserStatisticEntity? statisticEntity )
    {
        if ( statisticEntity == null )
        {
            throw new NoSuchUserException();
        }
        
        return new UserStatisticDto()
        {
            CreatedRecipesAmount = statisticEntity.CreatedRecipesAmount,
            LikedRecipesAmount = statisticEntity.CreatedRecipesLikesAmount,
            FavoritesRecipesAmount = statisticEntity.CreatedRecipesFavoritesAmount
        };
    } 
}