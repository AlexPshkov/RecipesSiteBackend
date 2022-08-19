using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions;

public static class TagEntityExtensions
{
    
    public static TagDto ConvertToTagDto( this TagEntity ?  tagEntity )
    {
        if ( tagEntity == null ) return new TagDto();
        return new TagDto()
        {
            id = tagEntity.Id,
            tagName = tagEntity.Name,
            tagDescription = tagEntity.Description,
            tagIconURL = tagEntity.IconUrl
        };
    } 
}