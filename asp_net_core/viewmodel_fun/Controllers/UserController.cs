using Microsoft.AspNetCore.Mvc;
namespace viewmodel_fun.Controllers;
using viewmodel_fun.Models;
    public class UserController : Controller
    {
        [HttpGet]
        [Route("user")]
        public IActionResult SingleUser()
        {
            User moose = new User()
            {
                firstName = "Moose",
                lastName = "Phillips"
            };
            return View(moose);
        }
    }