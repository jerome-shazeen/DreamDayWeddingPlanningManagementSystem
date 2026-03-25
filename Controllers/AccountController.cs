using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // TODO: In production, hash the password before saving it.
                user.Role = "Couple";
                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Registration successful. Please log in.";
                return RedirectToAction("Login");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage)
                                          .ToList();
            System.Diagnostics.Debug.WriteLine("Registration errors: " + string.Join(", ", errors));

            return View(user);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login using LoginViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                System.Diagnostics.Debug.WriteLine("Login ModelState errors: " + string.Join(", ", errors));
                return View(model);
            }

            var normalizedEmail = model.Email.Trim().ToLower();
            var user = _context.Users.FirstOrDefault(u =>
                u.Email.Trim().ToLower() == normalizedEmail && u.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("UserName", user.FullName);
                System.Diagnostics.Debug.WriteLine($"Login successful for user: {user.Email}");
                return RedirectToAction("Dashboard");
            }

            System.Diagnostics.Debug.WriteLine("Login failed for email: " + model.Email);
            ModelState.AddModelError("", "Invalid credentials.");
            return View(model);
        }

        // GET: /Account/Dashboard
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
