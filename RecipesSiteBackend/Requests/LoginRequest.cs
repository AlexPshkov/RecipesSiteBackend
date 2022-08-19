using System.ComponentModel.DataAnnotations;

namespace RecipesSiteBackend.Requests;

public class LoginRequest
{

    [Required]
    public string login { get; set; }
    
    [Required]
    public string password { get; set; }
}