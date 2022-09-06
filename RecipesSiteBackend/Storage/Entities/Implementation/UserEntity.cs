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
    
    public List<RecipeEntity> CreatedRecipes { get; set; } = new();
    public List<LikeEntity> Likes { get; set; } = new();
    public List<FavoriteEntity> Favorites { get; set; } = new();
}


public enum Role
{
    User, 
    Admin
}