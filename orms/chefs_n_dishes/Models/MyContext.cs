using Microsoft.EntityFrameworkCore;
namespace chefs_n_dishes.Models;
// the MyContext class representing a session with our MySQL 
// database allowing us to query for or save data
public class MyContext : DbContext 
{
    public MyContext(DbContextOptions options) : base(options) { }
    // the table name will come from the DbSet variable name
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Dish> Dishes { get; set; }
}