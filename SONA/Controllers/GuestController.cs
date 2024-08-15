using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONA.Data;
using SONA.Models;
using System.Linq;

namespace SONA.Controllers
{
    public class GuestController : Controller
    {
        private readonly DataContext db;

        public GuestController(DataContext db)
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

            var guestList = db.Guest.Where(x => !x.IsDelete).Include
                (g => g.Reservations).ToList();
            return View(guestList);
        }

        public IActionResult Details(int? id)
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var guest = db.Guest.Where(x => !x.IsDelete).Include
                (g => g.Reservations).FirstOrDefault();

            if (guest! == null)
            {
                return View(guest);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login");
            }
            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Guest guest)
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login");
            }

            if (guest != null && !String.IsNullOrWhiteSpace(guest.FirstName) && !String.IsNullOrWhiteSpace(guest.LastName))
            {
                db.Guest.Add(guest);
                db.SaveChanges();
                TempData["Message"] = "Guest added successfully.";
                TempData["Status"] = "true";
            }
            else
            {
                ViewData["Message"] = "Error Guest Added";
                ViewData["Status"] = "false";
            }
            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login");
            }

            if (id == null)
            {
                TempData["Message"] = "Guest not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            var guest = db.Guest.Where(x => x.GuestId == id && !x.IsDelete).Include(g => g.Reservations).FirstOrDefault();
            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();

            if (guest != null)
            {
                guest.IsDelete = true;//vri kalır ama silinmiş gibi görünür
                db.SaveChanges();
                TempData["Message"] = "Product Delete Successful.";
                TempData["Status"] = "true";
            }
            else
            {
                TempData["Message"] = "Not Found Product";
                TempData["Status"] = "false";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login");
            }

            if (id == null)
            {
                TempData["Message"] = "Guest not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            var guest = db.Guest.Where(x => x.GuestId == id && !x.IsDelete).Include(g => g.Reservations).FirstOrDefault();
            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();
                

            if (guest == null)
            {
                TempData["Message"] = "Guest not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            return View(guest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guest guest)
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login");
            }
            var editGuest = db.Guest.Where(x => x.GuestId == guest.GuestId && !x.IsDelete).Include(g => g.Reservations).FirstOrDefault();

            if (editGuest != null && !String.IsNullOrWhiteSpace(guest.FirstName) && !String.IsNullOrWhiteSpace(guest.LastName))
            {
                editGuest.FirstName = guest.FirstName;
                editGuest.LastName = guest.LastName;
                editGuest.Email = guest.Email;
                editGuest.PhoneNumber = guest.PhoneNumber;
                editGuest.IsStatus = guest.IsStatus;
                db.SaveChanges();
                ViewData["Message"] = "Guest Edit Successful";
                ViewData["Status"] = "true";
            }
            else
            {
                ViewData["Message"] = "Error Product Edit";
                ViewData["Status"] = "false";
            }
            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();
            return View(editGuest);
        
    }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                
                if (ValidateUser(login.Email, login.Password))
                {
                    UserManager.IsLogin = true;
                    UserManager.CurrentGuestId = GetGuestIdByEmail(login.Email); 

                    TempData["Message"] = "Login successful.";
                    TempData["Status"] = "true";
                    return RedirectToAction(nameof(Index));
                }

                ViewData["Message"] = "Email or password is incorrect.";
                ViewData["Status"] = "false";
            }

            return View(login);
        }

        
        private bool ValidateUser(string email, string password)
        {
            
            return email == "test@example.com" && password == "password123";
        }

        
        private int GetGuestIdByEmail(string email)
        {
            return 1; 
        }


        public IActionResult Logout()
        {
            UserManager.IsLogin = false;
            TempData["Message"] = "Logout successful.";
            TempData["Status"] = "true";
            return RedirectToAction("Login", "Account");
        }
    }
}
