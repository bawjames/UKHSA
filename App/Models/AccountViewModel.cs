namespace UKHSA.Models;
using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Forename { get; set; }

    [Required]
    public required string Surname { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords must match.")]
    public required string ConfirmPassword { get; set; }
}

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    public bool RememberMe { get; set; }
}
