using Microsoft.AspNetCore.Mvc;
namespace SurveyNamespace.Controllers;
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Results(string Name, string Location, string FaveLanguage, string Comment)
        {
            if (Name == null || Location == null || FaveLanguage == null) {
                return RedirectToAction("Index");
            } else {
                ViewBag.Name = Name;
                ViewBag.Location = Location;
                ViewBag.FaveLanguage = FaveLanguage;
                ViewBag.Comment = Comment;
                return View();
            }
        }
    }