using DeluxeHotelMVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// SESSION
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Error, HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// SESSION
app.UseSession();

// 🔥 LOGIN KONTROL MIDDLEWARE
app.Use(async (context, next) =>
{
    bool isLoggedIn = context.Session.GetInt32("UserID") != null;

    var path = context.Request.Path.Value.ToLower();

    bool allowed =
        path.Contains("/account/login") ||
        path.Contains("/account/register") ||
        path.Contains("/css") ||
        path.Contains("/js") ||
        path.Contains("/images");

    if (!isLoggedIn && !allowed)
    {
        context.Response.Redirect("/Account/Login");
        return;
    }

    await next();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
