using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using wedding_planner.Models;
using Microsoft.EntityFrameworkCore;

namespace wedding_planner.Controllers;

public class HomeController : Controller
    {
    private MyContext _context;

    public HomeController(MyContext context)
    {
        _context = context;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("Index");
        }
        else
        {
            User user = _context.Users
            .Include(u => u.Weddings)
            .ThenInclude(w => w.Wedding)
            .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            List<Wedding> weddings = _context.Weddings
            .Include(w => w.Attendees)
            .ThenInclude(a => a.User)
            .ToList();

            ViewBag.User = user;
            ViewBag.Weddings = weddings;
            return View();
        }
    }

    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        if(HttpContext.Session.GetInt32("UserId") == null)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    [HttpGet("/weddings/{WeddingId}")]
    public IActionResult Wedding(int WeddingId)
    {
        Wedding weddingInDb = _context.Weddings
        .Include(w => w.Attendees)
        .ThenInclude(a => a.User)
        .FirstOrDefault(w => w.WeddingId == WeddingId);

        if(weddingInDb != null)
        {
            ViewBag.Wedding = weddingInDb;
            return View();
        }
        else
        {
            return Redirect("/dashboard");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}