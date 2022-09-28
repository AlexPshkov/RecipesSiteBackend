using RecipesSiteBackend.Storage.Entities.Implementation.secondary;
using RecipesSiteBackend.Validators;

namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class UserEntity : AbstractEntity
{
    public Guid UserId { get; init; }

    private string _userName = "";
    public string UserName
    {
        get => _userName;
        set => _userName = UserValidators.ValidateName( value );
    }
    
    private string _login = "";
    public string Login
    {
        get => _login;
        set => _login = UserValidators.ValidateLogin( value );
    }

    private string _password = "";
    public string Password
    {
        get => _password;
        set => _password = UserValidators.ValidatePassword( value );
    }
    
    private string _description = "";
    public string Description
    {
        get => _description;
        set => _description = UserValidators.ValidateDescription( value );
    }
    
    public Role Role { get; init; }
    
    public List<RecipeEntity> CreatedRecipes { get; } = new();
    public List<LikeEntity> Likes { get; } = new();
    public List<FavoriteEntity> Favorites { get; } = new();
}

public enum Role
{
    User,
    Admin
}