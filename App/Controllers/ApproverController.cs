using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UKHSA.Models;
using UKHSA.Shared;

namespace UKHSA.Controllers;

public class ApproverController : Controller
{
     protected readonly UKHSA_DbContext _context;
    public ApproverController(UKHSA_DbContext context) => _context = context;

    public IActionResult ApproveRequest(int page = 1, int perPage = 20)
    {
        
        int totalItems = _context.Requests.Count();
        var requests = _context.Requests.ToList();

        var model = new Paginated<Request> {
            CurrentPage = page,
            PerPage = perPage,
            TotalItems = totalItems,
            Items = requests,
        };

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult DenyRequest()
    {
        return View();
    }
}
