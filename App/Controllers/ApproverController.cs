using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UKHSA.Models;
using UKHSA.Shared;

namespace UKHSA.Controllers;

[Authorize(Roles = "Approver, Admin")]
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

    [HttpGet]
    public IActionResult DenyRequest(int requestId)
    {
        var request = _context.Requests.Find(requestId);
        return View(request);
    }

    [HttpPost]
    public IActionResult DenyRequest(int requestId, string reason)
    {
        var request = _context.Requests.Find(requestId);

        if (request.Approval == null)
        {
            request.Approval = new Approval
            {
                Request = request,
                RejectedReason = reason,
                Approved = false,
                Timestamp = DateTime.Now
            };
        }
        else
        {
        request.Approval.Approved = false;
        request.Approval.RejectedReason = reason;
        request.Approval.Timestamp = DateTime.Now;
        }

        return RedirectToAction("ApproveRequest");
    }
}
