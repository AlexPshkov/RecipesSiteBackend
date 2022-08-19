using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Storage.Entities.Implementation;

public class UserEntity : AbstractEntity
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(250)]
    public string Login { get; set; }
    
    [Required] 
    [MaxLength(500)]
    public string Password { get; set; }
    
    [Required] 
    [MaxLength(500)]
    public string Description { get; set; }
    
    public Role Role { get; set; }
}


public enum Role
{
    User, 
    Admin
}