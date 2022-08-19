using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Services.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;
    
    public UserService(IUserRepository userRepository, ILogger<UserService> logger )
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    /**
     * Gets entity
     */
    public UserEntity ? GetUserById( Guid id )
    {
        return _userRepository.GetById( id );
    }
    
    /**
     * Gets entity
     */
    public UserEntity ?  GetUserByLogin( string login )
    {
        return _userRepository.GetByLogin( login );
    }
    
    /**
     * Save use entity
     */
    public void Save( UserEntity userEntity )
    {
        _logger.LogInformation( "Save entity to database {1}", userEntity.Login );
        _userRepository.Create( userEntity );
    }
    
    /**
     * Checks login and password. If ok, then return user object
     */
    public UserEntity ? GetByLoginAndPassword( string login, string password )
    {
        var userEntity = _userRepository.GetByLogin( login );
        if ( userEntity == null )
        {
            _logger.LogInformation( "No user with Login = {Login}", login );
            return null;
        }
        if ( userEntity.Password.Equals( password ) ) return userEntity;
        _logger.LogInformation( "Wrong password for Login = {Login} and Password = {Password}", login, password );
        return null;

    }
}