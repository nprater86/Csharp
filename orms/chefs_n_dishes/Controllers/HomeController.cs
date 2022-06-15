using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using chefs_n_dishes.Models;

namespace chefs_n_dishes.Controllers;

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
        List<Chef> chefsWithDishes = _context.Chefs.Include(chefs => chefs.CreatedDishes).ToList();
        return View(chefsWithDishes);
    }

    [HttpGet("new")]
    public IActionResult AddChef()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SaveChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddChef");
        }
    }

    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        List<Dish> dishesWithChef = _context.Dishes.Include(dish => dish.Creator).ToList();
        return View(dishesWithChef);
    }

    [HttpGet("dishes/new")]
    public IActionResult AddDish()
    {
        List<Chef> allChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = allChefs;
        return View();
    }

    [HttpPost]
    public IActionResult SaveDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Is Valid!");
            Console.WriteLine("---------------------------------");
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        else
        {
            List<Chef> allChefs = _context.Chefs.ToList();
            ViewBag.AllChefs = allChefs;
            return View("AddDish");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
