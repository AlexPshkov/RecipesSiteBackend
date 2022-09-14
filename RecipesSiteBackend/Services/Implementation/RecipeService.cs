using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Extensions.Entity;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;
using RecipesSiteBackend.Storage.UoW;
using RecipesSiteBackend.Validators;
using Action = RecipesSiteBackend.Storage.Entities.Implementation.Action;

namespace RecipesSiteBackend.Services.Implementation;

public class RecipeService : IRecipeService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecipeRepository _repository;
    private readonly ITagRepository _tagRepository;

    public RecipeService( IUnitOfWork unitOfWork, IRecipeRepository repository, ITagRepository tagRepository )
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _tagRepository = tagRepository;
    }
    
    public List<RecipeEntity> GetAllRecipes()
    {
        return _repository.GetAll();
    }

    public RecipeEntity GetRecipe( int recipeId )
    {
        var recipe = _repository.GetById( recipeId );
        if ( recipe == null )
        {
            throw new NoSuchRecipeException( recipeId );
        }
        recipe.Actions.Add( recipe.ConvertToRecipeActionEntity( Action.View ) );
        _unitOfWork.SaveChanges();
        return recipe;
    }

    private List<TagEntity> GetDomainTags( List<TagEntity> tags )
    {
        var list = new List<TagEntity>();
        foreach ( var tagEntity in tags )
        {
           list.Add( _tagRepository.GetByName( tagEntity.Name ) ?? tagEntity );
        }
        return list;
    } 
    
    public int SaveRecipe( RecipeEntity newRecipeEntity )
    {
        var newValidRecipe = newRecipeEntity.ValidateRecipe();
        newValidRecipe.Tags = GetDomainTags( newRecipeEntity.Tags );
        
        if ( newRecipeEntity.RecipeId == 0 )
        {
            _repository.Create( newValidRecipe );
            _unitOfWork.SaveChanges();
            return newValidRecipe.RecipeId;
        }
        
        var domainRecipe = _repository.GetById( newRecipeEntity.RecipeId ) ?? throw new NoSuchRecipeException( newRecipeEntity.RecipeId );

        if ( newValidRecipe.RecipeId != domainRecipe.RecipeId )
        {
            throw new NoPermException( "Another RecipeId" );
        }
        
        if ( newValidRecipe.UserId != domainRecipe.UserId )
        {
            throw new NoPermException( "Another UserId" );
        }
        
        _repository.Update( domainRecipe.Combine( newValidRecipe ) );
        _unitOfWork.SaveChanges();
        return newValidRecipe.RecipeId;
    }
    
    public void RemoveRecipe( int recipeId, Guid userId )
    {
        var recipeEntity = _repository.GetById( recipeId );

        if ( recipeEntity == null )
        {
            throw new NoSuchRecipeException( recipeId );
        }
        
        if ( recipeEntity.UserId != userId )
        {
            throw new NoPermException("Another userId");
        }
        
        _repository.Delete( recipeEntity );
        _unitOfWork.SaveChanges();
    }
    
    public RecipeEntity HandleLike( int recipeId, Guid userId )
    {
        var recipe = _repository.GetById( recipeId );
        if ( recipe == null )
        {
            throw new NoSuchRecipeException();
        }
        
        var domainLike = recipe.Likes.Find( input => input.UserId.Equals( userId ) );
        
        var likeEntity = new LikeEntity
        {
            LikeId = domainLike?.LikeId ?? 0,
            Recipe = recipe,
            UserId = userId
        };

        if ( domainLike != null )
        {
            recipe.Likes.Remove( domainLike );
        }
        else
        {
            recipe.Likes.Add(likeEntity );
        }
        recipe.Actions.Add( recipe.ConvertToRecipeActionEntity( Action.Like ) );
        
        _unitOfWork.SaveChanges();
        return recipe;
    }
    
    public RecipeEntity HandleFavorite( int recipeId, Guid userId )
    {
        var recipe = _repository.GetById( recipeId );
        if ( recipe == null )
        {
            throw new NoSuchRecipeException();
        }
        
        var domainFavorite = recipe.Favorites.Find( input => input.UserId.Equals( userId ) );
        
        var favoriteEntity = new FavoriteEntity()
        {
            FavoriteId = domainFavorite?.FavoriteId ?? 0,
            Recipe = recipe,
            UserId = userId
        };

        if ( domainFavorite != null )
        {
            recipe.Favorites.Remove( domainFavorite );
        }
        else
        {
            recipe.Favorites.Add(favoriteEntity );
        }
        
        recipe.Actions.Add( recipe.ConvertToRecipeActionEntity( Action.Favorite ) );
        _unitOfWork.SaveChanges();
        return recipe;
    }
    
    public RecipeEntity GetBestRecipe( Action action )
    {
        var recipe = _repository.GetBestRecipe( action ) ?? throw new NoSuchRecipeException();
        return recipe;
    }

    public async Task<List<RecipeEntity>> MakeSearch( string searchQuery )
    {
        return await _repository.MakeSearch( searchQuery );
    }
}