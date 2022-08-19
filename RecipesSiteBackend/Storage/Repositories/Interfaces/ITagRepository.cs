using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Repositories.Interfaces;

public interface ITagRepository : IEntityRepository<TagEntity>
{

    public List<TagEntity> GetAll();
    
    
    public TagEntity ?  GetById(int id);
    
    
    public TagEntity ?  GetByName(string name);

}