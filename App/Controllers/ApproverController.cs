using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UKHSA.Models;

namespace UKHSA.Controllers;

public class ApproverController : Controller
{
     protected readonly UKHSA_DbContext _context;
    public ApproverController(UKHSA_DbContext context) => _context = context;

    public IActionResult ApproveRequest()
    {
        var requests = _context.Requests.ToList();
        return View(requests);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
