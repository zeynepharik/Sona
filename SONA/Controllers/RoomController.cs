using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONA.Data;
using SONA.Models;


namespace SONA.Controllers
{
   
        public class RoomController : Controller
        {
            private readonly DataContext db;



            public RoomController(DataContext db)
            {
                this.db = db;
            }
            [HttpPost]
            public IActionResult CheckAvailability(DateTime CheckInDate, DateTime CheckOutDate, int NumberOfGuests)
            {
                var model = new RoomSearchViewModel
                {
                    CheckInDate = CheckInDate,
                    CheckOutDate = CheckOutDate,
                    NumberOfGuests = NumberOfGuests
                };

                if (model.CheckInDate == default(DateTime) || model.CheckOutDate == default(DateTime))
                {
                    ModelState.AddModelError(string.Empty, "Check-in and check-out dates must be provided.");
                    model.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
                    return View("AvailableRooms", model);
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

                
                var roomTypeIds = availableRooms.Select(r => r.RoomTypeId).Distinct().ToList();
                var filteredRooms = roomTypeIds.Select(id => availableRooms
                    .Where(r => r.RoomTypeId == id)
                    .FirstOrDefault()).ToList();

                model.AvailableRooms = filteredRooms;
                model.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
                model.Nights = nights;

                return View("AvailableRooms", model);
            }


        public IActionResult SearchRooms(RoomSearchViewModel model)
        {
            if (model == null)
            {
                model = new RoomSearchViewModel();
            }

            
            if (!ModelState.IsValid || model.AvailableRooms == null)
            {
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

        [HttpPost]
       
        public IActionResult CreateReservation(int RoomId, DateTime CheckInDate, DateTime CheckOutDate, int NumberOfGuests, decimal TotalPrice)
        {
            if (!AccountController.girisyapildi)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login", "Account");
            }

            var UserId = db.UserRegistration
                .Where(x => x.Email == AccountController.email)
                .Select(x => x.UserId)
                .FirstOrDefault();

            var reservation = new Reservation
            {
                GuestId = UserId,
                RoomId = RoomId,
                CheckInDate = DateTime.Now,
                CheckOutDate = DateTime.Now.AddMonths(1),
                NumberOfGuests = NumberOfGuests,
                TotalPrice = TotalPrice,
                IsStatus = true,
                IsDelete = false
            };

            db.Reservation.Add(reservation);
            db.SaveChanges();

            return View("CreatedReservation", reservation);
        }

        [HttpGet]
        public IActionResult CreatedReservation()
        {
          
            return View();
        }

        public IActionResult Index()
        {
            if (!AccountController.girisyapildi)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login", "Account");
            }

            var roomList = db.Room.Where(x => !x.IsDelete).Include
                (g => g.Reservations).ToList();
            return View(roomList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = db.Room
                .Where(r => r.RoomId == id && !r.IsDelete)
                .Include(r => r.RoomType)
                .FirstOrDefault();

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Room.Add(room);
                db.SaveChanges();
                TempData["Message"] = "Room added successfully.";
                TempData["Status"] = "true";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
            return View(room);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["Message"] = "Room not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            var room = db.Room
                .Where(r => r.RoomId == id && !r.IsDelete)
                .Include(r => r.RoomType)
                .FirstOrDefault();

            if (room == null)
            {
                TempData["Message"] = "Room not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Room room)
        {
            var existingRoom = db.Room
                .Where(r => r.RoomId == room.RoomId && !r.IsDelete)
                .FirstOrDefault();

            if (existingRoom != null && ModelState.IsValid)
            {
                existingRoom.RoomNumber = room.RoomNumber;
                existingRoom.RoomTypeId = room.RoomTypeId;
                existingRoom.IsAvailable = room.IsAvailable;
                db.SaveChanges();
                TempData["Message"] = "Room updated successfully.";
                TempData["Status"] = "true";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoomTypes = db.RoomType.Where(rt => !rt.IsDelete).ToList();
            return View(room);
        }

       

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var room = db.Room
                .Where(r => r.RoomId == id && !r.IsDelete)
                .FirstOrDefault();

            if (room != null)
            {
                room.IsDelete = true;
                db.SaveChanges();
                TempData["Message"] = "Room deleted successfully.";
                TempData["Status"] = "true";
            }
            else
            {
                TempData["Message"] = "Room not found.";
                TempData["Status"] = "false";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
