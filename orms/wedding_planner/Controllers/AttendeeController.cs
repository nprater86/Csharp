using Microsoft.AspNetCore.Mvc;

using wedding_planner.Models;
namespace wedding_planner.Controllers;

public class AttendeeController : Controller
    {
    private MyContext _context;

    public AttendeeController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("rsvp/{UserId}/{WeddingId}")]
    public IActionResult RSVP(int UserId, int WeddingId)
    {
        if(HttpContext.Session.GetInt32("UserId") != UserId)
        {
            return Redirect("/dashboard");
        }
        else
        {
            Attendee newAttendee = new Attendee();
            newAttendee.UserId = UserId;
            newAttendee.WeddingId = WeddingId;
            _context.Add(newAttendee);
            _context.SaveChanges();

            return Redirect("/dashboard");
        }
    }

    [HttpGet("un-rsvp/{AttendeeId}")]
    public IActionResult UNRSVP(int AttendeeId)
    {
        Attendee attendeeInDb = _context.Attendees.FirstOrDefault(a => a.AttendeeId == AttendeeId);
        if(attendeeInDb == null || HttpContext.Session.GetInt32("UserId") != attendeeInDb.UserId)
        {
            return Redirect("/dashboard");
        }
        else
        {
            _context.Attendees.Remove(attendeeInDb);
            _context.SaveChanges();
            return Redirect("/dashboard");
        }
    }
}