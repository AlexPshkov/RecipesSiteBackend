using RecipesSiteBackend.Dto.Secondary;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Secondary;

public static class FavoriteEntityExtensions
{
    
    public static FavoriteDto ConvertToFavoriteDto( this FavoriteEntity ?  favoriteEntity )
    {
        if ( favoriteEntity == null ) return new FavoriteDto();
        return new FavoriteDto()
        {
            id = favoriteEntity.Id,
            user = favoriteEntity.User.ConvertToUserDto(),
        };
    } 
}