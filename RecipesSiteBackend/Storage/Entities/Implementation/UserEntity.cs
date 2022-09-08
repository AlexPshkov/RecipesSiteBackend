using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class UserEntity : AbstractEntity
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    
    public Role Role { get; set; }
    
    
    public List<RecipeEntity> CreatedRecipes { get; set; }
    public List<LikeEntity> Likes { get; set; }
    public List<FavoriteEntity> Favorites { get; set; }
}


public enum Role
{
    User, 
    Admin
}