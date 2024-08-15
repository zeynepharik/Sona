using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONA.Data;
using SONA.Models;
using System.Linq;

namespace SONA.Controllers
{
    public class ReservationController : Controller
    {
        private readonly DataContext db;

        public ReservationController(DataContext db)
        {
            this.db = db;
        }

        public IActionResult SearchRooms()
        {
            var model = new RoomSearchViewModel
            {
                RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SearchRooms(RoomSearchViewModel model)
        {
            if (model == null)
            {
                model = new RoomSearchViewModel();
            }

            if (!ModelState.IsValid)
            {
                model.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
                return View(model);
            }

            if (model.CheckInDate == default(DateTime) || model.CheckOutDate == default(DateTime))
            {
                ModelState.AddModelError(string.Empty, "Check-in and check-out dates must be provided.");
                model.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
                return View(model);
            }

            var nights = (model.CheckOutDate - model.CheckInDate).Days;

            var availableRooms = db.Room
                .Include(r => r.RoomType)
                .Where(r => r.IsAvailable && !r.IsDelete
                            && r.RoomType.Capacity >= model.NumberOfGuests
                            && !db.Reservation.Any(res => res.RoomId == r.RoomId
                            && res.CheckInDate < model.CheckOutDate
                            && res.CheckOutDate > model.CheckInDate))
                .ToList();

            model.AvailableRooms = availableRooms;
            model.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
            model.Nights = nights;

            return View(model);
        }

        [HttpGet]
        public IActionResult BookRoom(int roomTypeId, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            var roomType = db.RoomType.Find(roomTypeId);
            if (roomType == null)
            {
                TempData["Message"] = "Room type not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(SearchRooms));
            }

            var availableRooms = db.Room
                .Where(r => r.RoomTypeId == roomTypeId
                            && !r.IsDelete
                            && r.IsAvailable
                            && !db.Reservation.Any(res => res.RoomId == r.RoomId
                            && res.CheckInDate < checkOutDate
                            && res.CheckOutDate > checkInDate))
                .ToList();

            var model = new RoomSearchViewModel
            {
                RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList(),
                AvailableRooms = availableRooms,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                NumberOfGuests = numberOfGuests
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookRoom(RoomSearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
                model.AvailableRooms = db.Room
                    .Where(r => r.RoomTypeId == model.SelectedRoomTypeId
                                && !r.IsDelete
                                && r.IsAvailable
                                && !db.Reservation.Any(res => res.RoomId == r.RoomId
                                && res.CheckInDate < model.CheckOutDate
                                && res.CheckOutDate > model.CheckInDate))
                    .ToList();
                return View(model);
            }

            var reservation = new Reservation
            {
                GuestId = UserManager.GetCurrentGuestId(),
                RoomId = model.SelectedRoomId,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                NumberOfGuests = model.NumberOfGuests,
                IsStatus = true
            };

            db.Reservation.Add(reservation);
            db.SaveChanges();

            TempData["Message"] = "Room booked successfully.";
            TempData["Status"] = "true";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CompleteReservation(int selectedRoomId, bool isPaidAtHotel, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            var room = db.Room.Include(r => r.RoomType).FirstOrDefault(r => r.RoomId == selectedRoomId);

            if (room == null || !room.IsAvailable)
            {
                return BadRequest("Room not available.");
            }

            var nights = (checkOutDate - checkInDate).Days;

            var userId = HttpContext.Request.Cookies["UserId"];

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User not found.");
            }

            var guest = db.Guest.FirstOrDefault(g => g.UserId == userId);

            if (guest == null)
            {
                return BadRequest("Guest not found.");
            }

            var guestId = guest.GuestId;

            var reservation = new Reservation
            {
                GuestId = guestId,
                RoomId = selectedRoomId,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                NumberOfGuests = numberOfGuests,
                TotalPrice = CalculatePrice(room.RoomType.BasePrice, nights),
                IsStatus = true,
                IsDelete = false,
                Payment = new Payment
                {
                    Amount = CalculatePrice(room.RoomType.BasePrice, nights),
                    PaymentDate = DateTime.Now,
                    IsSuccessful = true,
                    IsPaidAtHotel = isPaidAtHotel
                }
            };

            db.Reservation.Add(reservation);
            db.SaveChanges();

            return RedirectToAction("Success");
        }

        private decimal CalculatePrice(decimal basePrice, int nights)
        {
            return basePrice * nights;
        }
    }
}
