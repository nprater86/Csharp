using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using simple_login_registration.Models;

namespace simple_login_registration.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("user/register")]
    public IActionResult Register(IndexViewModel modelData)
    {
        RegUser regUser = modelData.regUser;
        if(ModelState.IsValid){
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("user/login")]
    public IActionResult Login(IndexViewModel modelData)
    {
        LogUser logUser = modelData.logUser;
        if(ModelState.IsValid){
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet]
    [Route("success")]
    public IActionResult Success()
    {
        return View();
    }
}
