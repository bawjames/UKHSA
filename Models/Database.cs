namespace UKHSA.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public List<Role> Role { get; set; }
}

public enum Role
{
    Standard,
    Approver,
    Admin
}

public class Request
{
    public int Id { get; set; }
}

public class Dataset
{
    public int Id { get; set; }
}

public class Approval
{
}
