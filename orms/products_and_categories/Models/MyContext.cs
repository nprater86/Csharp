using Microsoft.EntityFrameworkCore;
namespace products_and_categories.Models;
// the MyContext class representing a session with our MySQL 
// database allowing us to query for or save data
public class MyContext : DbContext 
{
    public MyContext(DbContextOptions options) : base(options) { }
    // the table name will come from the DbSet variable name
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Categorization> Categorizations { get; set; }
}