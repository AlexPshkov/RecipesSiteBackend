using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Storage.Repositories.Interfaces;

namespace RecipesSiteBackend.Storage.Repositories.Implementation;

public class StepRepository : IStepRepository
{
    
    private readonly DataBaseContext _dbContext;

    public StepRepository (DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<StepEntity> GetAll()
    {
        return _dbContext.Steps.ToList();
    }

    public StepEntity ? GetById( int id )
    {
        return _dbContext.Steps.SingleOrDefault(step => id.Equals( step.StepId ));
    }
    
    public void Create( StepEntity entity )
    {
        _dbContext.Steps.Add( entity );
        _dbContext.SaveChanges();
    }

    public void Update( StepEntity entity )
    {
        _dbContext.Steps.Update( entity );
        _dbContext.SaveChanges();
    }

    public void Delete( StepEntity entity )
    {
        _dbContext.Steps.Remove( entity );
        _dbContext.SaveChanges();
    }
}