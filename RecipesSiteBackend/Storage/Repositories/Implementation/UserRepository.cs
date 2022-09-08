using Microsoft.EntityFrameworkCore;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class UserRepository : IUserRepository
{
    
    private readonly DataBaseContext _dbContext;

    public UserRepository (DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<UserEntity> GetAll()
    {
        return _dbContext.UserAccounts.ToList();
    }

    public UserEntity ? GetById( Guid id )
    {
        return _dbContext.UserAccounts.SingleOrDefault(user => id.Equals( user.UserId ));
    }

    public UserEntity ?  GetByLogin( string login )
    {
        return _dbContext.UserAccounts.SingleOrDefault(user => login == user.Login);
    }

    public List<RecipeEntity> GetCreatedRecipes( Guid userId )
    {
        var user = _dbContext.UserAccounts
            .Include( x => x.CreatedRecipes )
            .SingleOrDefault(user => userId.Equals( user.UserId ));
        return user == null ? new List<RecipeEntity>() : user.CreatedRecipes.ToList();
    }

    public List<RecipeEntity> GetFavorites( Guid userId )
    {
        var user = _dbContext.UserAccounts
            .Include( x => x.Favorites )
            .SingleOrDefault(user => userId.Equals( user.UserId ));
        return user == null ? new List<RecipeEntity>() : user.Favorites.ConvertAll( input => input.Recipe );
    }
    
    public List<RecipeEntity> GetLikes( Guid userId )
    {
        var user = _dbContext.UserAccounts
            .Include( x => x.Likes )
            .SingleOrDefault(user => userId.Equals( user.UserId ));
        return user == null ? new List<RecipeEntity>() : user.Likes.ConvertAll( input => input.Recipe );
    }
    
    public void Create( UserEntity entity )
    {
        _dbContext.UserAccounts.Add( entity );
    }

    public void Update( UserEntity entity )
    {
        _dbContext.UserAccounts.Update( entity );
    }

    public void Delete( UserEntity entity )
    {
        _dbContext.UserAccounts.Remove( entity );
    }
}