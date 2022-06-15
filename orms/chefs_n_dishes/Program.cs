using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using chefs_n_dishes.Models;

var builder = WebApplication.CreateBuilder(args);
var connectString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyContext>(options => {
    options.UseMySql(connectString, ServerVersion.AutoDetect(connectString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
