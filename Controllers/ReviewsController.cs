using DeluxeHotelMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ReviewsController : Controller
{
    private readonly AppDbContext _context;

    public ReviewsController(AppDbContext context)
    {
        _context = context;
    }

    // ✔ TÜM YORUMLAR
    public IActionResult Index()
    {
        var reviews = _context.Reviews
            .Include(r => r.User)
            .OrderByDescending(r => r.CreatedAt)
            .ToList();

        return View(reviews);
    }

    // ✔ YORUM EKLEME SAYFASI (GET)
    public IActionResult Create()
    {
        if (HttpContext.Session.GetInt32("UserID") == null)
            return RedirectToAction("Login", "Account");

        return View();
    }

    // ✔ YORUM EKLEME (POST)
    [HttpPost]
    [HttpPost]
    public IActionResult Create(int rating, string comment)
    {
        int? userId = HttpContext.Session.GetInt32("UserID");

        if (userId == null)
            return RedirectToAction("Login", "Account");

        // ⭐ int → byte dönüşümü burada yapılmalı
        byte ratingValue = (byte)rating;

        var review = new Review
        {
            Rating = ratingValue,
            Comment = comment,
            UserID = userId.Value,
            CreatedAt = DateTime.Now
        };

        _context.Reviews.Add(review);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}
