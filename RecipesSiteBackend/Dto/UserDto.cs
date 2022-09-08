namespace RecipesSiteBackend.Dto;

public class UserDto
{
    public string Id { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }
    
    public string Login { get; set; }
    
    public string Description { get; set; }
    
    public string Role { get; set; }
}