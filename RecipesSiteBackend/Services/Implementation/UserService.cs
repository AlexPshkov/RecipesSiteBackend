using RecipesSiteBackend.Dto;
using RecipesSiteBackend.Exceptions.Implementation;
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
    
    public Task<UserEntity?> GetUserById( Guid id )
    {
        return _userRepository.GetById( id );
    }

    public Task<UserEntity?> GetUserByLogin( string login )
    {
        return _userRepository.GetByLogin( login );
    }
    
    public Task<List<RecipeEntity>> GetFavorites( Guid userId, int start, int end )
    {
        return _userRepository.GetFavorites( userId, start, end );
    }
    
    public Task<List<RecipeEntity>> GetCreatedRecipes( Guid userId, int start, int end )
    {
        return _userRepository.GetCreatedRecipes( userId, start, end );
    }
    
    public async Task<UserStatisticEntity> GetUserStatistic( Guid userId )
    {
        return await _userRepository.GetUserStatistic( userId );
    }
    
    public async Task<UserEntity> Save( UserEntity userEntity )
    {
        var newValidUser = userEntity.ValidateUser();
        var domainUser = await _userRepository.GetById( userEntity.UserId );
        
        if ( domainUser == null)
        { 
            _userRepository.Create( newValidUser );
            await _unitOfWork.SaveChanges();
            return userEntity;
        }

        if ( domainUser.UserId != newValidUser.UserId )
        {
            throw new NoPermException( "Another UserId" );
        }

        if ( domainUser.Login != newValidUser.Login )
        {
            if ( await _userRepository.GetByLogin( newValidUser.Login ) != null )
            {
                throw new UserAlreadyExistsException( newValidUser.Login );
            }
        }
        
        _userRepository.Update( domainUser.Combine( newValidUser ) );
        await _unitOfWork.SaveChanges();
        return domainUser;
    }
}