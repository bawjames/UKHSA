namespace UKHSA.Controllers;

using UKHSA.Models;
using Microsoft.EntityFrameworkCore;

public class UKHSA_DbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Dataset> Datasets { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Approval> Approvals { get; set; }

    public UKHSA_DbContext(DbContextOptions<UKHSA_DbContext> options) : base(options) {}
}
