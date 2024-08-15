
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SONA.Data;
using SONA.Models;
using System.Linq;
using System.Threading.Tasks;
using YourNamespace.Models;

public class AccountController : Controller
{
    private readonly DataContext db;

    public static bool girisyapildi = false;
    public static string email = "";


    public AccountController(DataContext db)
    {
        this.db = db;
    }
    [HttpGet]
    public IActionResult Register()
    {
        if (girisyapildi == true)
        {
            return RedirectToAction("Index", "Home");
          
        }
        else
        {
            return View();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(UserRegistration model)
    {
      
            
            if (db.UserRegistration.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Bu e-posta adresi zaten kullanılıyor.");
                return View(model);
            }

           
            db.UserRegistration.Add(model);
            db.SaveChanges();

        girisyapildi = true;
        email = model.Email;
            TempData["Message"] = "Kayıt başarılı.";
        

        return View(model);
    }


    [HttpGet]
    public IActionResult Login()
    {
        if( girisyapildi == true)
        {
            
            return RedirectToAction("Index", "Home");

        }
        else
        {
            return View();
        }
        
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
       
            var user = db.UserRegistration
                .SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);

            if (user != null)
            {
                
                TempData["Message"] = "Giriş başarılı.";
            email = model.Email;
            girisyapildi = true;
            return RedirectToAction("Index", "Home");
        }
            else
            {
            TempData["Message"] = "Giriş hatalı.";
            ModelState.AddModelError("", "E-posta veya şifre hatalı.");
            return View(model);
        }
        

       
    }

    public IActionResult Logout()
    {
        
        TempData["Message"] = "Başarıyla çıkış yapıldı.";
        girisyapildi = false;
        return RedirectToAction("Login");
    }



    
}
