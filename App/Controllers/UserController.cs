using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UKHSA.Models;
using UKHSA.Shared;

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
        return View();
    }

    public IActionResult Requests(int page = 1, int perPage = 20)
    {

        var allRequests = _context.Requests
                          .Where(r => r.UserId == _userManager.GetUserId(User))
                          .ToList();

        int totalItems = allRequests.Count();

        var model = new Paginated<Request> {
            CurrentPage = page,
            PerPage = perPage,
            TotalItems = totalItems,
            Items = allRequests,
        };

        return View(model);
    }

    public IActionResult RequestDocument()
    {
        List<Dataset> datasets = _context.Datasets.OrderBy(e => e.Timestamp).ToList();
        return View(datasets);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
