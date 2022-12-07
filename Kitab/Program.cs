using Microsoft.EntityFrameworkCore;
using Kitab.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KitabDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KitabDbContext") ?? throw new InvalidOperationException("Connection string 'KitabDbContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStaticFiles();

app.Run();

//Seed Database
KitabDbInitializer.Seed(app);
