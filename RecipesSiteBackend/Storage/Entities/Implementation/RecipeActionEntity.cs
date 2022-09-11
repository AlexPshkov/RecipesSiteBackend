﻿namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class RecipeActionEntity : AbstractEntity
{
 
    public int ActionId { get; set; }
    public Action Action { get; set; }

    public int RecipeId { get; set; }
    public RecipeEntity Recipe { get; set; }
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}

public enum Action
{
    Favorite,
    Like, 
    View
}
