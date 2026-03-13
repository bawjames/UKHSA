namespace UKHSA.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    // NOTE: Id field is inherited from IdentityUser

    public required string Forename { get; set; }
    public required string Surname { get; set; }
    public required List<Role> Roles { get; set; }

    [InverseProperty("User")]
    public required List<Request> Requests { get; set; }
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

    [ForeignKey("Approval")]
    public int ApprovalId { get; set; }
    [ForeignKey("User")]
    public required int UserId { get; set; }
    [ForeignKey("Dataset")]
    public required int DatasetId { get; set; }
}

public class Dataset
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int AccessLevel { get; set; }

    [InverseProperty("Dataset")]
    public required List<Request> Requests { get; set; }
 }

public class Approval
{
    public bool Approved { get; set; }
    public DateTime ApprovedDateTime { get; set; }
    public string? RejectedReason { get; set; }

    [InverseProperty("Approval")]
    public required Request Requests { get; set; }
}
