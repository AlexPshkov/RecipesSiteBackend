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

    public TagEntity ? GetById( int id )
    {
        return _dbContext.Tags.SingleOrDefault(tag => id.Equals( tag.TagId ));
    }

    public TagEntity ? GetByName( string name )
    {
        return _dbContext.Tags.SingleOrDefault(tag => name == tag.Name);
    }

    public void Create( TagEntity entity )
    {
        _dbContext.Tags.Add( entity );
        _dbContext.SaveChanges();
    }

    public void Update( TagEntity entity )
    {
        _dbContext.Tags.Update( entity );
        _dbContext.SaveChanges();
    }

    public void Delete( TagEntity entity )
    {
        _dbContext.Tags.Remove( entity );
        _dbContext.SaveChanges();
    }
}