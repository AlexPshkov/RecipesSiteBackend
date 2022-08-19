using RecipesSiteBackend.Dto;

namespace RecipesSiteBackend.Services.Implementation;

public class StorageService : IStorage
{
    

    private static readonly List<TagDto> _tags = new()
    {
        new TagDto()
        {
            id = 1,
            tagName = "Простые блюда",
            tagDescription = "Время приготвления таких блюд не более 1 часа",
            tagIconURL = "../../../assets/images/main-page/svg/filters/book-icon.svg"
        },
        new TagDto()
        {
            id = 2,
            tagName = "Детское",
            tagDescription = "Самые полезные блюда которые можно детям любого возраста",
            tagIconURL = "../../../assets/images/main-page/svg/filters/toy-icon.svg"
        },
        new TagDto()
        {
            id = 3,
            tagName = "От шеф-поваров",
            tagDescription = "Требуют умения, времени и терпения, зато как в ресторане",
            tagIconURL = "../../../assets/images/main-page/svg/filters/hat-icon.svg"
        },
        new TagDto()
        {
            id = 4,
            tagName = "На праздник",
            tagDescription = "Чем удивить гостей, чтобы все были сыты за праздничным столом",
            tagIconURL = "../../../assets/images/main-page/svg/filters/firework-icon.svg"
        },
    };

    private static readonly List<RecipeDto> _recipes = new()
    {
        new RecipeDto()
        {
            recipeName = "Тыквенный супчик на кокосовом молоке",
            recipeDescription =
                "Если у вас осталась тыква, и вы не знаете что с ней сделать, то это решение для вас! Ароматный, согревающий суп-пюре на кокосовом молоке. Можно даже в Пост!",
            imageURL = "../../../assets/images/main-page/soup.webp",
            authorName = "@glazest",
            requiredTime = "35 минут",
            servingsAmount = "5 порций",
            favoritesAmount = "16",
            likesAmount = "8",
            currentTags = _tags,
        },
        new RecipeDto()
        {
            recipeName = "Мясные фрикадельки",
            recipeDescription =
                "Мясные фрикадельки в томатном соусе - несложное и вкусное блюдо, которым можно порадовать своих близких.  ",
            imageURL = "https://i.scdn.co/image/ab67616d0000b2737f158d901d17cece6bef2211",
            authorName = "@horilka ",
            requiredTime = "90  минут",
            servingsAmount = "4 персоны",
            favoritesAmount = "4",
            likesAmount = "7",
            currentTags = _tags,
        }, 
        new RecipeDto()
        {
            recipeName = "Мясные фрикадельки",
            recipeDescription =
                "Мясные фрикадельки в томатном соусе - несложное и вкусное блюдо, которым можно порадовать своих близких.  ",
            imageURL = "https://i.scdn.co/image/ab67616d0000b2737f158d901d17cece6bef2211",
            authorName = "@horilka ",
            requiredTime = "90  минут",
            servingsAmount = "4 персоны",
            favoritesAmount = "4",
            likesAmount = "7",
            currentTags = _tags,
        },
        new RecipeDto()
        {
            recipeName = "Самовар-Самоваров",
            recipeDescription =
                "Мясные фрикадельки в томатном соусе - несложное и вкусное блюдо, которым можно порадовать своих близких.  ",
            imageURL = "https://tulavar.ru/upload/iblock/4e7/6f1be348fe0953abdb9d5684b88577ef.jpg",
            authorName = "@horilka ",
            requiredTime = "900  минут",
            servingsAmount = "4 персоны",
            favoritesAmount = "4",
            likesAmount = "7",
            currentTags = _tags,
        }
    };
    
    public List<TagDto> getTags()
    {
        return _tags;
    }

    public List<RecipeDto> getRecipes()
    {
        return _recipes;
    }
}