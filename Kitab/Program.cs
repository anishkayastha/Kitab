using Microsoft.EntityFrameworkCore;
using Kitab.Data;
using Kitab.Data.Services;
using Kitab.Data.Cart;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KitabDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KitabDbContext") ?? throw new InvalidOperationException("Connection string 'KitabDbContext' not found.")));

//Services configuration
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed Database
KitabDbInitializer.Seed(app);

app.Run();
