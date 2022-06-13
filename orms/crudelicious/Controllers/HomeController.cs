using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using crudelicious.Models;

namespace crudelicious.Controllers;

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
        ViewBag.AllDishes = _context.Dishes.ToList();
        return View();
    }

    [HttpGet("new")]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Dishes.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("New");
        }
    }

    [HttpGet("{DishId}")]
    public IActionResult Detail(int DishId)
    {
        Dish targetDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
        return View(targetDish);
    }

    [HttpGet("delete/{DishId}")]
    public IActionResult Delete(int DishId)
    {
        Dish targetDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
        _context.Dishes.Remove(targetDish);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("edit/{DishId}")]
    public IActionResult Edit(int DishId)
    {
        Dish targetDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
        return View(targetDish);
    }

    [HttpPost("edit/{DishId}")]
    public IActionResult Update(int DishId, Dish updatedDish)
    {
        if(ModelState.IsValid)
        {
            Dish targetDish = _context.Dishes.FirstOrDefault(d => d.DishId == DishId);
            targetDish.Name = updatedDish.Name;
            targetDish.Chef = updatedDish.Chef;
            targetDish.Calories = updatedDish.Calories;
            targetDish.Tastiness = updatedDish.Tastiness;
            targetDish.Description = updatedDish.Description;
            targetDish.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Edit");
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
