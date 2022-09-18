using RecipesSiteBackend.Exceptions.Implementation;
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

    public Task<List<RecipeEntity>> GetAllRecipes( int start, int end )
    {
        return _repository.GetAll( start, end );
    }

    public async Task<RecipeEntity> GetRecipe( int recipeId )
    {
        var recipe = await _repository.GetById( recipeId );
        if ( recipe == null )
        {
            throw new NoSuchRecipeException( recipeId );
        }

        recipe.Actions.Add( recipe.ConvertToRecipeActionEntity( Action.View ) );
        await _unitOfWork.SaveChanges();
        return recipe;
    }

    private async Task<List<TagEntity>> GetDomainTags( List<TagEntity> tags )
    {
        var list = new List<TagEntity>();
        foreach ( var tagEntity in tags )
        {
            var domainTag = await _tagRepository.GetByName( tagEntity.Name );
            list.Add( domainTag ?? tagEntity );
        }
        return list;
    }

    public async Task<int> SaveRecipe( RecipeEntity newRecipeEntity )
    {
        var newValidRecipe = newRecipeEntity.ValidateRecipe();
        newValidRecipe.Tags = await GetDomainTags( newRecipeEntity.Tags );

        if ( newRecipeEntity.RecipeId == 0 )
        {
            _repository.Create( newValidRecipe );
            await _unitOfWork.SaveChanges();
            return newValidRecipe.RecipeId;
        }

        var domainRecipe = await _repository.GetById( newRecipeEntity.RecipeId );

        if ( domainRecipe == null )
        {
            throw new NoSuchRecipeException( newRecipeEntity.RecipeId );
        }

        if ( newValidRecipe.RecipeId != domainRecipe.RecipeId )
        {
            throw new NoPermException( "Another RecipeId" );
        }

        if ( newValidRecipe.UserId != domainRecipe.UserId )
        {
            throw new NoPermException( "Another UserId" );
        }

        _repository.Update( domainRecipe.Combine( newValidRecipe ) );
        await _unitOfWork.SaveChanges();
        return newValidRecipe.RecipeId;
    }

    public async Task<bool> RemoveRecipe( int recipeId, Guid userId )
    {
        var recipeEntity = await _repository.GetById( recipeId );

        if ( recipeEntity == null )
        {
            throw new NoSuchRecipeException( recipeId );
        }

        if ( recipeEntity.UserId != userId )
        {
            throw new NoPermException( "Another userId" );
        }

        _repository.Delete( recipeEntity );
        return await _unitOfWork.SaveChanges();
    }

    public async Task<RecipeEntity> HandleLike( int recipeId, Guid userId )
    {
        var recipe = await _repository.GetById( recipeId );
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
            recipe.Likes.Add( likeEntity );
        }

        recipe.Actions.Add( recipe.ConvertToRecipeActionEntity( Action.Like ) );

        await _unitOfWork.SaveChanges();
        return recipe;
    }

    public async Task<RecipeEntity> HandleFavorite( int recipeId, Guid userId )
    {
        var recipe = await _repository.GetById( recipeId );
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
            recipe.Favorites.Add( favoriteEntity );
        }

        recipe.Actions.Add( recipe.ConvertToRecipeActionEntity( Action.Favorite ) );
        await _unitOfWork.SaveChanges();
        return recipe;
    }

    public async Task<RecipeEntity> GetBestRecipe( Action action )
    {
        var recipe = await _repository.GetBestRecipe( action );
        if ( recipe == null )
        {
            throw new NoSuchRecipeException();
        }

        return recipe;
    }

    public Task<List<RecipeEntity>> MakeSearch( string searchQuery, int start, int end )
    {
        return _repository.MakeSearch( searchQuery, start, end );
    }
}