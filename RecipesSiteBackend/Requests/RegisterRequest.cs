using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Requests;

public class RegisterRequest
{

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Login { get; set; }
    
    [Required]
    public string Password { get; set; }
}