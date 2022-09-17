using Microsoft.EntityFrameworkCore;
using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class TagRepository : ITagRepository
{
    
    private readonly DataBaseContext _dbContext;

    public TagRepository (DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<TagEntity> GetAll()
    {
        return _dbContext.Tags.ToList();
    }

    public Task<TagEntity?> GetById( int id )
    {
        return _dbContext.Tags.SingleOrDefaultAsync(tag => id.Equals( tag.TagId ));
    }

    public Task<TagEntity?> GetByName( string name )
    {
        return _dbContext.Tags.SingleOrDefaultAsync(tag => name == tag.Name);
    }

    public async void Create( TagEntity entity )
    {
        await _dbContext.Tags.AddAsync( entity );
    }

    public void Update( TagEntity entity )
    {
        _dbContext.Tags.Update( entity );
    }

    public void Delete( TagEntity entity )
    {
        _dbContext.Tags.Remove( entity );
    }
}