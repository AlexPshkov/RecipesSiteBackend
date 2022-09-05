using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Repositories.Interfaces;
using RecipesSiteBackend.Storage.UoW;

namespace RecipesSiteBackend.Services.Implementation;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public UserEntity? GetUserById( Guid id )
    {
        return _userRepository.GetById( id );
    }
    
    public UserEntity?  GetUserByLogin( string login )
    {
        return _userRepository.GetByLogin( login );
    }
    
    public List<RecipeEntity> GetFavorites( Guid userId )
    {
        return _userRepository.GetFavorites( userId );
    }
    
    public List<RecipeEntity> GetLikes( Guid userId )
    {
        return _userRepository.GetLikes( userId );
    }
    
    public List<RecipeEntity> GetCreatedRecipes( Guid userId )
    {
        return _userRepository.GetCreatedRecipes( userId );
    }
    
    public void Save( UserEntity userEntity )
    {
        _userRepository.Create( userEntity );
        _unitOfWork.SaveChanges();
    }
    
    public UserEntity? GetByLoginAndPassword( string login, string password )
    {
        var userEntity = _userRepository.GetByLogin( login );
        if ( userEntity == null )
        {
            return null;
        }
        return userEntity.Password.Equals( password ) ? userEntity : null;
    }
}