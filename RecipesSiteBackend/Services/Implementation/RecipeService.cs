using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Storage.Entities.Implementation;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;
using RecipesSiteBackend.Storage.UoW;

namespace RecipesSiteBackend.Services.Implementation;

public class RecipeService : IRecipeService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecipeRepository _repository;

    public RecipeService( IUnitOfWork unitOfWork, IRecipeRepository repository )
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public List<RecipeEntity> GetAllRecipes()
    {
        return _repository.GetAll();
    }

    public RecipeEntity GetRecipe( int recipeId)
    {
        var recipe = _repository.GetById( recipeId );
        if ( recipe == null )
        {
            throw new NoSuchRecipeException( recipeId );
        }
        return recipe;
    }
    
    public bool SaveRecipe( RecipeEntity recipeEntity )
    {
        _repository.Create( recipeEntity );
        _unitOfWork.SaveChanges();
        return true;
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
        _unitOfWork.SaveChanges();
        return recipe;
    }
}