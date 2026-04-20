
namespace UKHSA.Models;
using System.ComponentModel.DataAnnotations;

public class RoleManagementViewModel
{
    [Required]
    public string UserId { get; set; } = "";

    public bool IsUser { get; set; }
    public bool IsApprover { get; set; }
    public bool IsAdmin { get; set; }
}
