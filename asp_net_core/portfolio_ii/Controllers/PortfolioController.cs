using Microsoft.AspNetCore.Mvc;
namespace PortfolioNamespace.Controllers;
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("projects")]
        public IActionResult Projects()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }