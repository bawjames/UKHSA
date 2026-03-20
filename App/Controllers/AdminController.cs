using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UKHSA.Models;

namespace UKHSA.Controllers;

public class AdminController : Controller
{
    protected readonly UKHSA_DbContext _context;
    public AdminController(UKHSA_DbContext context) => _context = context;

    public IActionResult Users(int page = 1, int perPage = 20)
    {
        int totalItems = _context.Users.Count();

        var allUsers = _context.Users
                          .ToList();

        var model = new Paginated<Users> {
            CurrentPage = page,
            PerPage = perPage,
            TotalItems = totalItems,
            Items = allRequests,
        };

        return View(model);
    }

    public IActionResult AddDocument()
    {
        var documents = _context.Datasets.ToList;
        return View(documents);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}