using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using products_and_categories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace products_and_categories.Controllers;

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
        return RedirectToAction("Products");
    }

    //-------------------------------------------
    //Product Controls
    //-------------------------------------------

    [HttpGet("products")]
    public IActionResult Products()
    {
        var productsWithCategories = _context.Products
        .Include(p => p.Categories)
        .ThenInclude(c => c.Category);
        ViewBag.Products = productsWithCategories;

        return View();
    }

    [HttpPost]
    public IActionResult CreateProduct(Product newProduct)
    {
        if(ModelState.IsValid)
        {
            if(_context.Products.Any(p => p.Name == newProduct.Name))
            {
                var productsWithCategories = _context.Products
                .Include(p => p.Categories)
                .ThenInclude(c => c.Category);
                ViewBag.Products = productsWithCategories;
                ModelState.AddModelError("Name", "Product already exists");
                return View("Products");
            }
            else
            {
                _context.Add(newProduct);
                _context.SaveChanges();
                return Redirect("/products");
            }
        }
        else
        {
            var productsWithCategories = _context.Products
            .Include(p => p.Categories)
            .ThenInclude(c => c.Category);
            ViewBag.Products = productsWithCategories;
            return View("Products");
        }
    }

    [HttpGet("products/{ProductId}")]
    public IActionResult Product(int ProductId)
    {
        //get product
        var productWithCategories = _context.Products
        .Include(p => p.Categories)
        .ThenInclude(c => c.Category)
        .FirstOrDefault(p => p.ProductId == ProductId);
        ViewBag.Product = productWithCategories;

        //get categories
        var categories = _context.Categories
        .Include(c => c.Products)
        .ThenInclude(p => p.Product)
        .Where(c => !(c.Products.Any(p => p.ProductId == ProductId)));
        ViewBag.Categories = categories;
        return View();
    }

    [HttpPost]
    public IActionResult AddCategoryToProduct(Categorization newCat)
    {
        _context.Add(newCat);
        _context.SaveChanges();
        return Redirect($"/products/{newCat.ProductId}");
    }

    //-------------------------------------------
    //Category Controls
    //-------------------------------------------

    [HttpGet("categories")]
    public IActionResult Categories()
    {
        var categoriesWithProducts = _context.Categories
        .Include(c => c.Products)
        .ThenInclude(p => p.Product);
        ViewBag.Categories = categoriesWithProducts;

        return View();
    }

    [HttpPost]
    public IActionResult CreateCategory(Category newCategory)
    {
        if(ModelState.IsValid)
        {
            if(_context.Categories.Any(c => c.Name == newCategory.Name))
            {
                ModelState.AddModelError("Name", "Category already exists");
                var categoriesWithProducts = _context.Categories
                .Include(c => c.Products)
                .ThenInclude(p => p.Product);
                ViewBag.Categories = categoriesWithProducts;
                return View("Categories");
            }
            else
            {
                _context.Add(newCategory);
                _context.SaveChanges();
                return Redirect("/categories");
            }
        }
        else
        {
            var categoriesWithProducts = _context.Categories
            .Include(c => c.Products)
            .ThenInclude(p => p.Product);
            ViewBag.Categories = categoriesWithProducts;
            return View("Categories");
        }
    }

    [HttpGet("categories/{CategoryId}")]
    public IActionResult Category(int CategoryId)
    {
        //get category
        var categoryWithProducts = _context.Categories
        .Include(c => c.Products)
        .ThenInclude(c => c.Product)
        .FirstOrDefault(c => c.CategoryId == CategoryId);
        ViewBag.Category = categoryWithProducts;

        //get products
        var products = _context.Products
        .Include(p => p.Categories)
        .ThenInclude(c => c.Category)
        .Where(p => !(p.Categories.Any(c => c.CategoryId == CategoryId)));
        ViewBag.Products = products;
        return View();
    }

    [HttpPost]
    public IActionResult AddProductToCategory(Categorization newProd)
    {
        _context.Add(newProd);
        _context.SaveChanges();
        return Redirect($"/categories/{newProd.CategoryId}");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}