using Microsoft.AspNetCore.Mvc;
namespace TimeNamespace.Controllers;
    public class TimeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }