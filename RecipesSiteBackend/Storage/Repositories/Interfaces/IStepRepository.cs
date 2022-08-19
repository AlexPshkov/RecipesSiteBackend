using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface IStepRepository : IEntityRepository<StepEntity>
{

    public List<StepEntity> GetAll();
    
    
    public StepEntity ?  GetById(int id);
    
}