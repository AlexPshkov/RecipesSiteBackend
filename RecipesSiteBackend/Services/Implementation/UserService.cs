using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Extensions.Entity;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Repositories.Interfaces;
using RecipesSiteBackend.Storage.UoW;
using RecipesSiteBackend.Validators;

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
    
    public UserEntity? GetFullUserById( Guid id )
    {
        return _userRepository.GetFullById( id );
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
    
    public UserEntity Save( UserEntity userEntity )
    {
        var newValidUser = userEntity.ValidateUser();
        var domainUser = _userRepository.GetById( userEntity.UserId );
        
        if ( domainUser == null)
        { 
            _userRepository.Create( newValidUser );
            _unitOfWork.SaveChanges();
            return userEntity;
        }

        if ( domainUser.UserId != newValidUser.UserId )
        {
            throw new NoPermException( "Another UserId" );
        }

        if ( domainUser.Login != newValidUser.Login )
        {
            if ( _userRepository.GetByLogin( newValidUser.Login ) != null )
            {
                throw new UserAlreadyExistsException( newValidUser.Login );
            }
        }
        
        _userRepository.Update( domainUser.Combine( newValidUser ) );
        _unitOfWork.SaveChanges();
        return domainUser;
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