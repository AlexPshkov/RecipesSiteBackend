using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class LikeRepository : ILikeRepository
{
    
    private readonly DataBaseContext _dbContext;

    public LikeRepository (DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<LikeEntity> GetAll()
    {
        return _dbContext.Likes.ToList();
    }

    public LikeEntity ? GetById( int id )
    {
        return _dbContext.Likes.SingleOrDefault(recipe => id.Equals( recipe.Id ));
    }

    public List<LikeEntity> GetUserLikes( Guid userId )
    {
        return _dbContext.Likes.Where( like => like.User.Id.Equals( userId ) ).ToList();
    }

    public List<LikeEntity> GetRecipeLikes( int recipeId )
    {
        return _dbContext.Likes.Where( like => like.Id.Equals( recipeId ) ).ToList();
    }
    
    public void Create( LikeEntity entity )
    {
        _dbContext.Likes.Add( entity );
        _dbContext.SaveChanges();
    }

    public void Update( LikeEntity entity )
    {
        _dbContext.Likes.Update( entity );
        _dbContext.SaveChanges();
    }

    public void Delete( LikeEntity entity )
    {
        _dbContext.Likes.Remove( entity );
        _dbContext.SaveChanges();
    }
}