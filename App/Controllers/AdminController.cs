using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UKHSA.Models;

namespace UKHSA.Controllers;

public class AdminController : Controller
{
    protected readonly UKHSA_DbContext _context;
    public AdminController(UKHSA_DbContext context) => _context = context;

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