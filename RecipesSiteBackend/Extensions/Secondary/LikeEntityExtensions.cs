using RecipesSiteBackend.Dto.Secondary;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Secondary;

public static class LikeEntityExtensions
{
    
    public static LikeDto ConvertToLikeDto( this LikeEntity ?  likeEntity )
    {
        if ( likeEntity == null ) return new LikeDto();
        return new LikeDto()
        {
            id = likeEntity.Id,
            user = likeEntity.User.ConvertToUserDto()
        };
    } 
}