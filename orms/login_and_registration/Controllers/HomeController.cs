using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using login_and_registration.Models;
using Microsoft.AspNetCore.Http;

namespace login_and_registration.Controllers;

public class HomeController : Controller
{
    private MyContext _context;

    public HomeController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            //lookup to see if email already registered
            if(_context.Users.Any(u => u.Email == newUser.Email))
            {
                //return to Index if email already exists
                ModelState.AddModelError("Email","Email already exists");
                return View("Index");
            }
            //hash password
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            //save user to DB
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetString("FirstName",newUser.FirstName);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitLogin(LoginUser user)
    {
        if(ModelState.IsValid)
        {
            //lookup user by email
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            //See if user was found
            if(userInDb == null)
            {
                //if user not found, produce error and send to login
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Login");
            }
            //hash password
            var hasher = new PasswordHasher<LoginUser>();
            //verify provided password matches hashed password in db
            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.Password);
            //result can be compared to 0 for failure
            if(result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("Login");
            }
            HttpContext.Session.SetString("FirstName",userInDb.FirstName);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Login");
        }
    }

    [HttpGet]
    [Route("success")]
    public IActionResult Success()
    {
        if(HttpContext.Session.GetString("FirstName") == null)
        {
            return RedirectToAction("Login");
        }
        else
        {
            return View();
        }
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
