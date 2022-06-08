using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers;
using viewmodel_fun.Models;
    public class UsersController : Controller
    {
        [HttpGet]
        [Route("users")]
        public IActionResult Users()
        {
            User moose = new User(){firstName = "Moose", lastName = "Phillips"};
            User sarah = new User(){firstName = "Sara"};
            User jerry = new User(){firstName = "Jerry"};
            User rene = new User(){firstName = "Rene", lastName = "Ricky"};
            User barbarah = new User(){firstName = "Barbarah"};

            List<User> newUsers = new List<User>();
            newUsers.Add(moose);
            newUsers.Add(sarah);
            newUsers.Add(jerry);
            newUsers.Add(rene);
            newUsers.Add(barbarah);

            Users userList = new Users()
            {
                users = newUsers
            };

            return View(userList);
        }
    }