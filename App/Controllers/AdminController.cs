using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using UKHSA.Models;

namespace UKHSA.Controllers;

// [Authorize(Roles = "Admin")]
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
    public IActionResult AddDocument()
    {
        var documents = _context.Datasets.ToList();
        return View(documents);
    }

    [HttpGet]
    public IActionResult AddDataset(AddDatasetViewModel model)
    {
        var datasets = _context.Datasets.ToList();
        return View(datasets);
    }

    public IActionResult RoleManagement()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
