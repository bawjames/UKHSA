using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UKHSA.Models;

namespace UKHSA.Controllers;

public class UserController : Controller
{
    protected readonly UKHSA_DbContext _context;
    private readonly UserManager<User> _userManager;

    public UserController(UKHSA_DbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Home()
    {
        var users = _context.Users.ToList();

        return View(users);
    }

    public IActionResult Requests()
    {
        var requests = _context.Requests
        .Where(r => r.UserId == _userManager.GetUserId(User))
        .ToList();

        return View(requests);
    }

    public IActionResult RequestDocument()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
