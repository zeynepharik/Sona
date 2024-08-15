using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONA.Data;
using SONA.Models;


namespace SONA.Controllers
{
   
    public class RoomTypeController : Controller
    {
        private readonly DataContext db;

        public RoomTypeController(DataContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login");
            }

            var roomTypeList = db.Room.Where(x => !x.IsDelete).Include
                (g => g.Reservations).ToList();
            return View(roomTypeList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomType = db.RoomType
                .Where(rt => rt.RoomTypeId == id && !rt.IsDelete)
                .FirstOrDefault();

            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                db.RoomType.Add(roomType);
                db.SaveChanges();
                TempData["Message"] = "Room type added successfully.";
                TempData["Status"] = "true";
                return RedirectToAction(nameof(Index));
            }

            return View(roomType);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["Message"] = "Room type not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            var roomType = db.RoomType
                .Where(rt => rt.RoomTypeId == id && !rt.IsDelete)
                .FirstOrDefault();

            if (roomType == null)
            {
                TempData["Message"] = "Room type not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            return View(roomType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RoomType roomType)
        {
            var existingRoomType = db.RoomType
                .Where(rt => rt.RoomTypeId == roomType.RoomTypeId && !rt.IsDelete)
                .FirstOrDefault();

            if (existingRoomType != null && ModelState.IsValid)
            {
                existingRoomType.TypeName = roomType.TypeName;
                existingRoomType.BasePrice = roomType.BasePrice;
                existingRoomType.Capacity = roomType.Capacity;
                db.SaveChanges();
                TempData["Message"] = "Room type updated successfully.";
                TempData["Status"] = "true";
                return RedirectToAction(nameof(Index));
            }

            return View(roomType);
        }

        

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var roomType = db.RoomType
                .Where(rt => rt.RoomTypeId == id && !rt.IsDelete)
                .FirstOrDefault();

            if (roomType != null)
            {
                roomType.IsDelete = true;
                db.SaveChanges();
                TempData["Message"] = "Room type deleted successfully.";
                TempData["Status"] = "true";
            }
            else
            {
                TempData["Message"] = "Room type not found.";
                TempData["Status"] = "false";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
