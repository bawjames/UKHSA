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

    public async Task<IActionResult> Requests(int page = 1, int perPage = 20)
    {
        

        var UserRequests = (from r in _context.Requests
                            join d in _context.Datasets on r.DatasetId equals d.Id
                            join a in _context.Approvals on r.Id equals a.RequestId
                            where r.UserId == _userManager.GetUserId(User)
                            orderby r.Timestamp
                            select new RequestsDto
                            {
                                Title = d.Title,
                                Approved = a.Approved,
                                Reason = a.RejectedReason,
                                ReqTime = r.Timestamp,
                                AppTime = a.Timestamp,
                                AppExp = a.Expires
                            }).ToList();

//        var allRequests = _context.Requests
//                          .Where(r => r.UserId == _userManager.GetUserId(User))
//                          .OrderBy(r => r.Timestamp)
//                          .ToList();

        int totalItems = UserRequests.Count();
        Console.WriteLine(totalItems);

        var model = new Paginated<RequestsDto> {
            CurrentPage = page,
            PerPage = perPage,
            TotalItems = totalItems,
            Items = UserRequests,
        };

        return View(model);
    }

    public IActionResult RequestDocument()
    {
        List<Dataset> datasets = _context.Datasets.ToList();
        return View(datasets);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
