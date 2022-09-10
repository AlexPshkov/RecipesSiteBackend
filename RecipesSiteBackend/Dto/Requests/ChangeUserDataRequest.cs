namespace RecipesSiteBackend.Dto.Requests;

public class ChangeUserDataRequest : UserDto
{
    public string Id { get; set; }
    public string Password { get; set; }
}