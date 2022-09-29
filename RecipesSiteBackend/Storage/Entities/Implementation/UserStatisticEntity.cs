namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class UserStatisticEntity : AbstractEntity
{
    public int CreatedRecipesAmount { get; init; }
    public int CreatedRecipesLikesAmount { get; init; }
    public int CreatedRecipesFavoritesAmount { get; init; }
}


