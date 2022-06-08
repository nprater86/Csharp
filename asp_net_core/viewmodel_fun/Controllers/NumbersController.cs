using Microsoft.AspNetCore.Mvc;
namespace viewmodel_fun.Controllers;
using viewmodel_fun.Models;
    public class NumbersController : Controller
    {
        [HttpGet]
        [Route("numbers")]
        public IActionResult Numbers()
        {
            Numbers newNumbers = new Numbers()
            {
                numbers = new int[] {1,2,3,10,43,5}
            };
            return View(newNumbers);
        }
    }