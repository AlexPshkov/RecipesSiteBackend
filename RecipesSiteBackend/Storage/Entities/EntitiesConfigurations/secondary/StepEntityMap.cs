using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Entities.EntitiesConfigurations.secondary;

public class StepEntityMap : IEntityTypeConfiguration<StepEntity>
{
    public void Configure( EntityTypeBuilder<StepEntity> builder )
    {
        builder.HasKey( x => x.StepId );
        builder.Property( x => x.StepId ).ValueGeneratedOnAdd();

        builder.Property( x => x.Description );
        builder.Property( x => x.RecipeId );
        
        builder.HasOne( x => x.Recipe )
            .WithMany( p => p.Steps );
        
        builder.Navigation( p => p.Recipe ).AutoInclude();
    }
}