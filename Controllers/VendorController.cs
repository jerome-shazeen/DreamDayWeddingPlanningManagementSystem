using Microsoft.AspNetCore.Mvc;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class VendorController : Controller
    {
        private readonly AppDbContext _context;

        public VendorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Vendor/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Vendor/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _context.Vendors.Add(vendor);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(vendor);
        }

        // GET: Vendor/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Vendor/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var vendor = _context.Vendors.FirstOrDefault(v => v.Email == email && v.Password == password);
            if (vendor != null)
            {
                return RedirectToAction("Dashboard");
            }
            ModelState.AddModelError("", "Invalid login credentials.");
            return View();
        }

        // GET: Vendor/Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
