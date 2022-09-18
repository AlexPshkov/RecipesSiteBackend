namespace RecipesSiteBackend.Dto.Requests;

public class RegisterRequest
{
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}