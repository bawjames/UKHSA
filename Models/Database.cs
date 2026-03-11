namespace UKHSA.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }
    public Role Role { get; set; }
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
