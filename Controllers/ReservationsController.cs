using DeluxeHotelMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ReservationsController : Controller
{
    private readonly AppDbContext _context;

    public ReservationsController(AppDbContext context)
    {
        _context = context;
    }

    // ➤ ODADAN REZERVASYON OLUŞTURMA SAYFASI
    public IActionResult Create(int roomId)
    {
        var room = _context.Rooms
            .Include(r => r.RoomType)
            .Where(r => r.RoomID == roomId)
            .Select(r => new
            {
                r.RoomID,
                r.RoomNumber,
                RoomName = r.RoomType.Name,
                r.RoomType.PricePerNight
            })
            .FirstOrDefault();

        if (room == null)
            return NotFound();

        ViewBag.Room = room;
        return View();
    }

    // ➤ REZERVASYON KAYDETME (POST)
    [HttpPost]
    public IActionResult Create(int roomId, DateTime checkIn, DateTime checkOut, int guests)
    {
        int? userId = HttpContext.Session.GetInt32("UserID");

        if (userId == null)
            return RedirectToAction("Login", "Account");

        // Oda bilgisi çekilir
        var room = _context.Rooms
            .Include(r => r.RoomType)
            .FirstOrDefault(r => r.RoomID == roomId);

        if (room == null)
            return NotFound();

        // Gün sayısı minimum 1
        int totalDays = (checkOut - checkIn).Days;
        if (totalDays <= 0)
            totalDays = 1;

        // Rezervasyonu kaydet
        var reservation = new Reservation
        {
            RoomID = roomId,
            UserID = userId.Value,
            CheckInDate = checkIn,
            CheckOutDate = checkOut,
            GuestCount = guests,
            CreatedAt = DateTime.Now
        };

        _context.Reservations.Add(reservation);
        _context.SaveChanges();

        return RedirectToAction("Success");
    }

    // ➤ BAŞARI SAYFASI
    public IActionResult Success()
    {
        return View();
    }

    // ➤ REZERVASYONLARIM SAYFASI
    public IActionResult MyReservations()
    {
        int? userId = HttpContext.Session.GetInt32("UserID");

        if (userId == null)
            return RedirectToAction("Login", "Account");

        var reservations = _context.Reservations
            .Where(r => r.UserID == userId)
            .Include(r => r.Room)
                .ThenInclude(room => room.RoomType)
            .OrderByDescending(r => r.CreatedAt)
            .ToList();

        return View(reservations);
    }
}
