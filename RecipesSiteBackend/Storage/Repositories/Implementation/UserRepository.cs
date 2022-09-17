using Microsoft.EntityFrameworkCore;
using RecipesSiteBackend.Exceptions.Implementation;
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
    
    public Task<UserEntity?> GetById( Guid id )
    {
        return _dbContext.UserAccounts.SingleOrDefaultAsync( user => id.Equals( user.UserId ) );
    }

    public Task<UserEntity?> GetByLogin( string login )
    {
        return _dbContext.UserAccounts.SingleOrDefaultAsync( user => login == user.Login );
    }

    /**
     * <remarks>Returns big entity with all children entities</remarks>
     */
    public Task<UserEntity?> GetFullById( Guid id )
    {
        return _dbContext.UserAccounts
            .Include( x => x.CreatedRecipes )
            .Include( x => x.Likes )
            .Include( x => x.Favorites )
            .SingleOrDefaultAsync( user => id.Equals( user.UserId ) );
    }
    
    public async Task<List<RecipeEntity>> GetCreatedRecipes( Guid userId )
    {
        var user = await _dbContext.UserAccounts
            .Include( x => x.CreatedRecipes )
            .SingleOrDefaultAsync(user => userId.Equals( user.UserId ));
        if ( user == null )
        {
            throw new NoSuchUserException();
        }
        return user.CreatedRecipes.ToList();
    }

    public async Task<List<RecipeEntity>> GetFavorites( Guid userId )
    {
        var user = await _dbContext.UserAccounts
            .Include( x => x.Favorites )
            .SingleOrDefaultAsync(user => userId.Equals( user.UserId ));
        if ( user == null )
        {
            throw new NoSuchUserException();
        }
        return user.Favorites.ConvertAll( input => input.Recipe );
    }
    
    public async Task<List<RecipeEntity>> GetLikes( Guid userId )
    {
        var user = await _dbContext.UserAccounts
            .Include( x => x.Likes )
            .SingleOrDefaultAsync(user => userId.Equals( user.UserId ));
        if ( user == null )
        {
            throw new NoSuchUserException();
        }
        return user.Likes.ConvertAll( input => input.Recipe );
    }
    
    public async void Create( UserEntity entity )
    {
        await _dbContext.UserAccounts.AddAsync( entity );
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