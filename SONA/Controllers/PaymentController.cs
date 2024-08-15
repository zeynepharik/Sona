using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONA.Data;
using SONA.Models;
using System.Linq;

namespace SONA.Controllers
{
    public class PaymentController : Controller
    {
        private readonly DataContext db;

        public PaymentController(DataContext db)
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

            var paymentList = db.Payment.Include(p => p.Reservation).ToList();
            return View(paymentList);
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

            var payment = db.Payment.Include(p => p.Reservation).FirstOrDefault(p => p.GuestId == id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
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
      
        public IActionResult Create(Payment payment)
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login", "Account");
            }

            if (payment != null && payment.Amount > 0 && payment.PaymentDate != default(DateTime))
            {
                db.Payment.Add(payment);
                db.SaveChanges();
                TempData["Message"] = "Payment added successfully.";
                TempData["Status"] = "true";
            }
            else
            {
                ViewData["Message"] = "Error: Payment could not be added. Please check the details.";
                ViewData["Status"] = "false";
            }

            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();
            return View(payment);
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
                TempData["Message"] = "Payment not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            var payment = db.Payment.Include(p => p.Reservation).FirstOrDefault(p => p.PaymentId == id);
            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();

            if (payment != null)
            {
                payment.IsDelete = true;
                db.SaveChanges();
                TempData["Message"] = "Payment deleted successfully.";
                TempData["Status"] = "true";
            }
            else
            {
                TempData["Message"] = "Payment not found.";
                TempData["Status"] = "false";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login", "Account");
            }

            if (id == null)
            {
                TempData["Message"] = "Payment not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }

            var payment = db.Payment.Include(p => p.Reservation).FirstOrDefault(p => p.PaymentId == id);
            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();

            if (payment == null)
            {
                TempData["Message"] = "Payment not found.";
                TempData["Status"] = "false";
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Payment payment)
        {
            if (!UserManager.IsLogin)
            {
                TempData["Message"] = "Unauthorized Entry";
                TempData["Status"] = "false";
                return RedirectToAction("Login");
            }
            var editPayment = db.Payment.Where(x => x.PaymentId == payment.PaymentId && !x.IsDelete).Include(g => g.Reservation).FirstOrDefault();

            if (editPayment != null && editPayment.Amount > 0)
            {
                editPayment.Amount = payment.Amount;
                editPayment.PaymentDate = payment.PaymentDate;
               
                editPayment.IsSuccessful = payment.IsSuccessful;
                editPayment.IsPaidAtHotel = payment.IsPaidAtHotel;
                db.SaveChanges();
                TempData["Message"] = "Payment updated successfully.";
                TempData["Status"] = "true";
            }
            else
            {
                ViewData["Message"] = "Payment not found.";
                ViewData["Status"] = "false";
            }

            ViewBag.ReservationList = db.Reservation.Where(x => x.IsStatus && !x.IsDelete).ToList();
            return View(editPayment);
        }


    }
}
