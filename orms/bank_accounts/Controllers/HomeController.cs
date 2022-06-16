using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bank_accounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank_accounts.Controllers;

public class HomeController : Controller
    {
    private MyContext _context;
    
    public HomeController(MyContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            return Redirect($"/account/{HttpContext.Session.GetInt32("UserId")}");
        }
        else
        {
            return View();
        }
    }

    [HttpPost]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email","Email already registered");
                return View("Index");
            }
            else
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Add(newUser);
                _context.SaveChanges();
                User user = _context.Users.FirstOrDefault(u => u.Email == newUser.Email);
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("UserName", user.FirstName);
                return Redirect($"/account/{user.UserId}");
            }
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet("login")]
    public IActionResult Login()
    {
        if(HttpContext.Session.GetInt32("UserId") != null)
        {
            return Redirect($"/account/{HttpContext.Session.GetInt32("UserId")}");
        }
        else
        {
            return View();
        }
    }

    public IActionResult LoginUser(LogUser submittedUser)
    {
        if(ModelState.IsValid)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == submittedUser.Email);

            if(userInDb == null)
            {
                ModelState.AddModelError("Password","Invalid Email/Password");
                return View("Login");
            }

            var hasher = new PasswordHasher<LogUser>();

            var result = hasher.VerifyHashedPassword(submittedUser, userInDb.Password, submittedUser.Password);

            if(result == 0)
            {
                ModelState.AddModelError("Password","Invalid Email/Password");
                return View("Login");
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                HttpContext.Session.SetString("UserName", userInDb.FirstName);
                return Redirect($"/account/{userInDb.UserId}");
            }
        }
        else
        {
            return View("Login");
        }
    }

    [HttpGet]
    [Route("account/{UserId:int}")]
    public IActionResult Dashboard(int UserId)
    {
        if(HttpContext.Session.GetString("UserName") == null || HttpContext.Session.GetInt32("UserId") != UserId)
        {
            return RedirectToAction("Index");
        }
        else
        {
            User user = _context.Users
            .Include(u => u.UserTransactions)
            .FirstOrDefault(u => u.UserId == UserId);

            ViewBag.user = user;

            return View();
        }
    }

    [HttpPost]
    public IActionResult CreateTransaction(Transaction submittedT)
    {
        User user = _context.Users
        .Include(u => u.UserTransactions)
        .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

        if((user.balance() + submittedT.Amount) < 0)
        {
            ViewBag.user = user;
            ModelState.AddModelError("Amount","Insufficient Funds");
            return View("Dashboard");
        }
        else
        {
            ViewBag.user = user;
            _context.Add(submittedT);
            _context.SaveChanges();
            return Redirect($"/account/{user.UserId}");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}