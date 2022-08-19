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
        return _dbContext.UserAccounts.SingleOrDefault(user => id.Equals( user.Id ));
    }

    public UserEntity ?  GetByLogin( string login )
    {
        return _dbContext.UserAccounts.SingleOrDefault(user => login == user.Login);
    }

    public void Create( UserEntity entity )
    {
        _dbContext.UserAccounts.Add( entity );
        _dbContext.SaveChanges();
    }

    public void Update( UserEntity entity )
    {
        _dbContext.UserAccounts.Update( entity );
        _dbContext.SaveChanges();
    }

    public void Delete( UserEntity entity )
    {
        _dbContext.UserAccounts.Remove( entity );
        _dbContext.SaveChanges();
    }
}