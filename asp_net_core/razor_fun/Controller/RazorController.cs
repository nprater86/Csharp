using Microsoft.AspNetCore.Mvc;
namespace RazorNamespace.Controllers;
    public class RazorController : Controller
    {
        [HttpGet]
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
    }