using RecipesSiteBackend.Dto.Secondary;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Secondary;

public static class TagEntityExtensions
{
    
    public static TagDto ConvertToTagDto( this TagEntity ?  tagEntity )
    {
        if ( tagEntity == null ) return new TagDto();
        return new TagDto()
        {
            id = tagEntity.Id,
            tagName = tagEntity.Name,
        };
    } 
}