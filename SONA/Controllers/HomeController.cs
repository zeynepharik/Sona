using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONA.Models;
using System.Diagnostics;

namespace SONA.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;

        private readonly ILogger<HomeController> _logger;
     
        public HomeController(ILogger<HomeController> logger, DataContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Rooms()
        {
            return View();
        }

        public IActionResult SearchRooms()
        {
            return View();
        }


        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Login()
        {
          
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]

        public IActionResult AvailableRooms()
        {
            if (AccountController.girisyapildi == false)
            {

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult AvailableRooms(DateTime checkIn, DateTime checkOut, int numberOfGuests)
        {
            
            if (checkIn == default(DateTime) || checkOut == default(DateTime))
            {
                
                ModelState.AddModelError(string.Empty, "Check-in and check-out dates must be provided.");
                return View("Error"); 
            }

            
            var nights = (checkOut - checkIn).Days;

            
            var availableRooms = db.Room
                .Include(r => r.RoomType)
                .Where(r => r.IsAvailable && !r.IsDelete
                            && r.RoomType.Capacity >= numberOfGuests
                            && !db.Reservation.Any(res => res.RoomId == r.RoomId
                            && res.CheckInDate < checkOut
                            && res.CheckOutDate > checkIn))
                .ToList();

            
            var viewModel = new RoomSearchViewModel
            {
                AvailableRooms = availableRooms,
                NumberOfGuests = numberOfGuests,
                Nights = nights
            };

            return View(viewModel);
        }

    }
}
