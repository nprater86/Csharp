using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace dojodachi.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        if(HttpContext.Session.GetString("Dojodachi") == null){
            Dojodachi dojodachi = new Dojodachi();
            HttpContext.Session.SetObjectAsJson("Dojodachi", dojodachi);
        }

        return View();
    }

    public IActionResult Status()
    {
        Dojodachi dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");

        Dictionary<string,object> dojodachiDict = dojodachi.toDict();

        return Json(dojodachiDict);
    }

    public IActionResult Feed()
    {
        Dojodachi dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
        string message = dojodachi.feed();
        HttpContext.Session.SetObjectAsJson("Dojodachi", dojodachi);
        return Json(message);
    }

    public IActionResult Play()
    {
        Dojodachi dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
        string message = dojodachi.play();
        HttpContext.Session.SetObjectAsJson("Dojodachi", dojodachi);
        return Json(message);
    }

    public IActionResult Work()
    {
        Dojodachi dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
        string message = dojodachi.work();
        HttpContext.Session.SetObjectAsJson("Dojodachi", dojodachi);
        return Json(message);
    }

    public IActionResult Sleep()
    {
        Dojodachi dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
        string message = dojodachi.sleep();
        HttpContext.Session.SetObjectAsJson("Dojodachi", dojodachi);
        return Json(message);
    }

    public IActionResult Reset()
    {
        HttpContext.Session.Clear();
        Dojodachi dojodachi = new Dojodachi();
        HttpContext.Session.SetObjectAsJson("Dojodachi", dojodachi);
        return Json("Game reset!");
    }

    public IActionResult CheckWin()
    {
        Dojodachi dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
        if(dojodachi.checkDead())
        {
            return Json("dead");
        }
        else if(dojodachi.checkWin())
        {
            return Json("win");
        }
        else
        {
            return Json("on");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
