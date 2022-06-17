using Microsoft.EntityFrameworkCore;
namespace wedding_planner.Models;
// the MyContext class representing a session with our MySQL 
// database allowing us to query for or save data
public class MyContext : DbContext 
{
    public MyContext(DbContextOptions options) : base(options) { }
    // the table name will come from the DbSet variable name
    public DbSet<User> Users { get; set; }
    public DbSet<Wedding> Weddings { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
}