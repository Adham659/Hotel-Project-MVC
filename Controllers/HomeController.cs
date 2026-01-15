using Microsoft.AspNetCore.Mvc;

namespace DeluxeHotelMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();  // Artık model göndermiyoruz.
        }
    }
}
