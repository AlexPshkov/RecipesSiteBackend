using RecipesSiteBackend.Storage.Entities.Implementation.secondary;

namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class UserEntity : AbstractEntity
{
    public Guid UserId { get; init; }
    
    public string UserName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    
    public Role Role { get; set; }
    
    public List<RecipeEntity> CreatedRecipes { get; } = new();
    public List<LikeEntity> Likes { get; } = new();
    public List<FavoriteEntity> Favorites { get; } = new();
}

public enum Role
{
    User, 
    Admin
}


