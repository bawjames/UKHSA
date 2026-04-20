using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using UKHSA.Models;
using UKHSA.Shared;

namespace UKHSA.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<User> _userManager;
    protected readonly UKHSA_DbContext _context;

    public AdminController(UserManager<User> userManager, UKHSA_DbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [HttpGet]
    public IActionResult AddDataset()
    {
        //var datasets = _context.Datasets.ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddDataset(AddDatasetViewModel Dataset)
    {

        Console.WriteLine(Dataset.AccessLevel);
        Dataset InputData = new Dataset
        {
            Title = Dataset.Title,
            Description = Dataset.Description,
            AccessLevel = Int32.Parse(Dataset.AccessLevel),
        };
        _context.Datasets.Add(InputData);
        await _context.SaveChangesAsync();
        return Redirect("/");
    }

    [HttpGet]
    public IActionResult RoleManagement(int page = 1, int perPage = 20)
    {
        var users = _context.Users.ToList();
        var items = users
        .Select(user => (user, roles: _userManager.GetRolesAsync(user).Result))
        .ToList();

        var model = new Paginated<(User user, IList<string> roles)> {
            CurrentPage = page,
            PerPage = perPage,
            Items = items
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> RoleManagement(RoleManagementViewModel model)
    {
        if (model == null)
        {
            return BadRequest("Invalid form data.");
        }

        var user = await _userManager.FindByIdAsync(model.UserId);

        if (model.IsUser) await _userManager.AddToRoleAsync(user, "User");
        else await _userManager.RemoveFromRoleAsync(user, "User");

        if (model.IsApprover) await _userManager.AddToRoleAsync(user, "Approver");
        else await _userManager.RemoveFromRoleAsync(user, "Approver");

        if (model.IsAdmin) await _userManager.AddToRoleAsync(user, "Admin");
        else await _userManager.RemoveFromRoleAsync(user, "Admin");

        return RedirectToAction(nameof(RoleManagement));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
