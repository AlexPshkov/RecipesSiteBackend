using Microsoft.EntityFrameworkCore;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Repositories;

public class DataBaseContext : DbContext
{
    public DbSet<UserEntity> UserAccounts { get; set; }
    public DbSet<RecipeEntity> Recipes { get; set; }
    
    public DbSet<FavoriteEntity> Favorites { get; set; }
    public DbSet<LikeEntity> Likes { get; set; }
    public DbSet<StepEntity> Steps { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<IngredientEntity> Ingredients { get; set; }
    
    
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating( ModelBuilder builder )
    {
        builder.Entity<RecipeEntity>( e =>
        {
            e.Navigation(p => p.User).AutoInclude();
            e.Navigation(p => p.Tags).AutoInclude();
            e.Navigation(p => p.Favorites).AutoInclude();
            e.Navigation(p => p.Likes).AutoInclude();
            e.Navigation(p => p.Ingredients).AutoInclude();
            e.Navigation(p => p.Steps).AutoInclude();
        });
        builder.Entity<FavoriteEntity>( e =>
        {
            e.Navigation(p => p.Recipe).AutoInclude();
            e.Navigation(p => p.User).AutoInclude();
        });
        builder.Entity<LikeEntity>( e =>
        {
            e.Navigation(p => p.Recipe).AutoInclude();
            e.Navigation(p => p.User).AutoInclude();
        });
        builder.Entity<IngredientEntity>( e => e.Navigation(p => p.Recipe).AutoInclude());
        builder.Entity<StepEntity>( e => e.Navigation(p => p.Recipe).AutoInclude());
    }

   
    
}