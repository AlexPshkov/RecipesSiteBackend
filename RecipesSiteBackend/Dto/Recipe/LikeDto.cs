namespace RecipesSiteBackend.Dto.Recipe;

public class LikeDto
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string UserId { get; set; }
}