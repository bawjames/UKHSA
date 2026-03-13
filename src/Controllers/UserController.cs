using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UKHSA.Models;

namespace UKHSA.Controllers;

public class UserController : Controller
{
    public IActionResult Home()
    {
        return View();
    }
    public IActionResult MyRequests()
    {
        return View();
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
