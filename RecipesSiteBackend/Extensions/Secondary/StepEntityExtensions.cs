using RecipesSiteBackend.Dto.Secondary;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Extensions.Secondary;

public static class StepEntityExtensions
{
    
    public static StepDto ConvertToStepDto( this StepEntity ?  stepEntity )
    {
        if ( stepEntity == null ) return new StepDto();
        return new StepDto()
        {
            id = stepEntity.Id,
            description = stepEntity.Description,
        };
    } 
}