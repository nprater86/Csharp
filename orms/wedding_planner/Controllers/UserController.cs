using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using wedding_planner.Models;
namespace wedding_planner.Controllers;

public class UserController : Controller
    {
    private MyContext _context;

    public UserController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email","Email already registered");
                return View("../Home/Index");
            }

            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);

            _context.Add(newUser);
            _context.SaveChanges();
            User user = _context.Users.FirstOrDefault(u => u.Email == newUser.Email);
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserName", user.FirstName);
            return Redirect("/dashboard");
        }
        else
        {
            return View("../Home/Index");
        }
    }

    [HttpPost]
    public IActionResult Login(LogUser user)
    {
        if(ModelState.IsValid)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == user.LogEmail);

            if(userInDb == null)
            {
                ModelState.AddModelError("LogPassword","Invalid Email/Password");
                return View("../Home/Index");
            }

            var hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LogPassword);

            if(result == 0)
            {
                ModelState.AddModelError("LogPassword","Invalid Email/Password");
                return View("../Home/Index");
            }

            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            HttpContext.Session.SetString("UserName", userInDb.FirstName);
            return Redirect("/dashboard");
        }
        else
        {
            return View("../Home/Index");
        }
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/");
    }

}