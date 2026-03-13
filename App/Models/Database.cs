namespace UKHSA.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    // NOTE: Id field is inherited from IdentityUser

    public required string Forename { get; set; }
    public required string Surname { get; set; }
    public Role Role { get; set; } = Role.Standard;

    public List<Request> Requests { get; set; } = [];
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
    public DateTime RequestDateTime { get; set; }

    public string? UserId { get; set; }
    public User? User { get; set; }

    public required int DatasetId { get; set; }
    public required Dataset Dataset { get; set; }

    public Approval? Approval { get; set; }
}

public class Dataset
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int AccessLevel { get; set; }

    public List<Request> Requests { get; set; } = [];
 }

public class Approval
{
    public int Id { get; set; }
    public bool Approved { get; set; }
    public DateTime ApprovedDateTime { get; set; }
    public string? RejectedReason { get; set; }

    public int RequestId { get; set; }
    [ForeignKey(nameof(RequestId))]
    public required Request Request { get; set; }
}
