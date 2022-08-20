namespace RecipesSiteBackend.Dto.Secondary;

public class LikeDto
{
    public int id { get; set; }
    public UserDto user { get; set; }
    public RecipeDto recipe { get; set; }
}