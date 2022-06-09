using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using random_passcode.Models;
using Microsoft.AspNetCore.Http;

namespace random_passcode.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        if(HttpContext.Session.GetInt32("counter") == null)
        {
            HttpContext.Session.SetInt32("counter", 0);
        }
        return View();
    }
    [HttpGet]
    public IActionResult GeneratePasscode()
    {
        int counter = HttpContext.Session.GetInt32("counter") ?? default(int);
        counter++;
        HttpContext.Session.SetInt32("counter", counter);
        Random rand = new Random();
        List<string> characterList = new List<string>(){"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z", "1","2","3","4","5","6","7","8","9","0"};
        string passcode = "";
        for(int i = 0; i < 14; i++){
            passcode += characterList[rand.Next(characterList.Count)];
        }
        Dictionary<string,object> data = new Dictionary<string,object>();
        data.Add("Passcode", passcode);
        data.Add("Counter",counter);
        return Json(data);
    }

    public IActionResult ClearCounter(){
        HttpContext.Session.SetInt32("counter", 1);
        return Json(HttpContext.Session.GetInt32("counter"));
    }
}
