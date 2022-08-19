using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Requests;

public class RegisterRequest
{

    [Required]
    public string name { get; set; }
    
    [Required]
    public string login { get; set; }
    
    [Required]
    public string password { get; set; }
}