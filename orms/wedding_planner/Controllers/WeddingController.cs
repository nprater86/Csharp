using Microsoft.AspNetCore.Mvc;

using wedding_planner.Models;
namespace wedding_planner.Controllers;

public class WeddingController : Controller
    {
    private MyContext _context;

    public WeddingController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult SaveWedding(Wedding newWedding)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();

            Attendee newAttendee = new Attendee();
            newAttendee.UserId = newWedding.UserId;
            newAttendee.WeddingId = newWedding.WeddingId;
            _context.Add(newAttendee);
            _context.SaveChanges();

            return Redirect("/dashboard");
        }
        else
        {
            return View("../Home/NewWedding");
        }
    }

    [HttpGet("weddings/delete/{WeddingId}")]
    public IActionResult DeleteWedding(int WeddingId)
    {
        Wedding wedding = _context.Weddings.FirstOrDefault(w => w.WeddingId == WeddingId);
        if(wedding == null || wedding.UserId != HttpContext.Session.GetInt32("UserId"))
        {
            return Redirect("/dashboard");
        }
        else
        {
            _context.Weddings.Remove(wedding);
            _context.SaveChanges();
            return Redirect("/dashboard");
        }
    }
}