using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class FavoriteRepository : IFavoriteRepository
{
    
    private readonly DataBaseContext _dbContext;

    public FavoriteRepository (DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<FavoriteEntity> GetAll()
    {
        return _dbContext.Favorites.ToList();
    }

    public FavoriteEntity ? GetById( int id )
    {
        return _dbContext.Favorites.SingleOrDefault(favorite => id.Equals( favorite.Id ));
    }

    public List<FavoriteEntity> GetUserFavorites( Guid userId )
    {
        return _dbContext.Favorites.Where( favorite => favorite.User.Id.Equals( userId ) ).ToList();
    }

    public List<FavoriteEntity> GetRecipeFavorites( int recipeId )
    {
        return _dbContext.Favorites.Where( favorite => favorite.Id.Equals( recipeId ) ).ToList();
    }
    
    public void Create( FavoriteEntity entity )
    {
        _dbContext.Favorites.Add( entity );
        _dbContext.SaveChanges();
    }

    public void Update( FavoriteEntity entity )
    {
        _dbContext.Favorites.Update( entity );
        _dbContext.SaveChanges();
    }

    public void Delete( FavoriteEntity entity )
    {
        _dbContext.Favorites.Remove( entity );
        _dbContext.SaveChanges();
    }
}