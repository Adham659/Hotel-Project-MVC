using DeluxeHotelMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeluxeHotelMVC.Controllers
{
    public class RoomsController : Controller
    {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rooms = _context.Rooms
                .Include(r => r.RoomType)
                .Include(r => r.RoomFeatures)
                    .ThenInclude(f => f.Feature)
                .ToList();

            return View(rooms);
        }
    }
}
