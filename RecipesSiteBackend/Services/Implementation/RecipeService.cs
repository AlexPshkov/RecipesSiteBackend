using RecipesSiteBackend.Dto.Recipe;
using RecipesSiteBackend.Exceptions;
using RecipesSiteBackend.Extensions.Entity;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;
using RecipesSiteBackend.Storage.UoW;

namespace RecipesSiteBackend.Services.Implementation;

public class RecipeService : IRecipeService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecipeRepository _repository;

    public RecipeService(IUnitOfWork unitOfWork, IRecipeRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }


    public List<RecipeDto> GetAllRecipes()
    {
        return _repository.GetAll().ConvertAll( input => input.ConvertToRecipeDto() );
    }

    public RecipeDto GetRecipe( int recipeId)
    {
        var recipe = _repository.GetById( recipeId );
        if ( recipe == null )
        {
            throw new NoSuchRecipeException( recipeId );
        }
        return recipe.ConvertToRecipeDto();
    }
    
    public RecipeDto HandleLike( int recipeId, Guid userId )
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
        return recipe.ConvertToRecipeDto();
    }
    
    public RecipeDto HandleFavorite( int recipeId, Guid userId )
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
        return recipe.ConvertToRecipeDto();
    }
}