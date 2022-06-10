using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using quoting_dojo.Models;

using DbConnection;

namespace quoting_dojo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("quotes")]
    public IActionResult SubmitQuote(Quote newQuote)
    {
        if(ModelState.IsValid)
        {
            string query = $"INSERT INTO quotes (name, quote, created_at, updated_at) VALUES ('{newQuote.name}', '{newQuote.quote}', NOW(), NOW());";

            DbConnector.Execute(query);
            return RedirectToAction("ListQuotes");
        }
        else
        {
            Console.WriteLine("error!");
            return View("Index");
        }
    }

    [HttpGet]
    [Route("quotes")]
    public IActionResult ListQuotes()
    {
        List<Dictionary<string,object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC;");
        ViewBag.Quotes = AllQuotes;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
