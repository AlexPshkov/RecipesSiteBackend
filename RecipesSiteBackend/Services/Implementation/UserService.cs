using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Extensions.Entity;
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
    
    public List<RecipeDto> GetFavorites( Guid userId )
    {
        return _userRepository.GetFavorites( userId ).ConvertAll( input => input.ConvertToRecipeDto() );
    }
    
    public List<RecipeDto> GetLikes( Guid userId )
    {
        return _userRepository.GetLikes( userId ).ConvertAll( input => input.ConvertToRecipeDto() );
    }
    
    public List<RecipeDto> GetCreatedRecipes( Guid userId )
    {
        return _userRepository.GetCreatedRecipes( userId ).ConvertAll( input => input.ConvertToRecipeDto() );
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