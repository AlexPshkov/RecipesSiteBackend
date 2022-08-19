namespace RecipesSiteBackend.Dto;

public class RecipeDto
{
    public int id { get; set; }
    public string recipeName { get; set; }
    public string recipeDescription { get; set; }

    public string imageURL { get; set; }
    public string authorName { get; set; }

    public string requiredTime { get; set; }
    public string servingsAmount { get; set; }

    public string favoritesAmount { get; set; }
    public string likesAmount { get; set; }
    public List<TagDto> currentTags { get; set; }
}