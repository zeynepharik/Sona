using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SONA.Controllers
{
    public class BookingController : Controller
    {
        private readonly DataContext db;

        public BookingController(DataContext db)
        {
            this.db = db;
        }


        [HttpPost]
        public IActionResult CheckAvailability(DateTime checkIn, DateTime checkOut, int guest, int rooms)
        {
            var availableRooms = db.Room
                .Include(r => r.RoomType)
                .Where(r => r.IsAvailable && !r.IsDelete &&
                            !db.Reservation.Any(res => res.RoomId == r.RoomId &&
                                                                ((res.CheckInDate < checkOut && res.CheckOutDate > checkIn))))
                .ToList();

            return View("AvailableRooms", availableRooms);
        }
    }
}

