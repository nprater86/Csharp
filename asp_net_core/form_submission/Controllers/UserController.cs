using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using form_submission.Models;

namespace form_submission.Controllers;

public class UserController : Controller
{
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("user/register")]
    public IActionResult Register(User user)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    public IActionResult Success()
    {
        return View();
    }
}
