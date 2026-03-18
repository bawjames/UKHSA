using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UKHSA.Models;

namespace UKHSA.Controllers;

// Move this to a different namespace
public class Paginated<T>
{
    public List<T> Items { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
}

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

    public IActionResult Requests(int page = 1, int pageSize = 20)
    {
        var requests = _context.Requests
                       .Where(r => r.UserId == _userManager.GetUserId(User))
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize)
                       .ToList();

        int totalItems = _context.Requests.Count();
        int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

        var model = new Paginated<Request> {
            CurrentPage = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            Items = requests,
        };

        return View(model);
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
