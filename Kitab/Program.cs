using Microsoft.EntityFrameworkCore;
using Kitab.Data;
using Kitab.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KitabDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KitabDbContext") ?? throw new InvalidOperationException("Connection string 'KitabDbContext' not found.")));

//Services configuration
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStaticFiles();

//Seed Database
KitabDbInitializer.Seed(app);

app.Run();
