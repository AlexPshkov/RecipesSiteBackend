using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Entities.EntitiesConfigurations.secondary;

public class TagEntityMap : IEntityTypeConfiguration<TagEntity>
{
    public void Configure( EntityTypeBuilder<TagEntity> builder )
    {
        builder.HasKey( x => x.TagId );
        builder.Property( x => x.TagId ).ValueGeneratedOnAdd();

        builder.Property( x => x.Name );

        builder.HasMany( x => x.Recipes )
            .WithMany( p => p.Tags );
    }
}