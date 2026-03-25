using Microsoft.AspNetCore.Mvc;
using DreamDayWeddingPlanningManagementSystem.Data;
using DreamDayWeddingPlanningManagementSystem.Models;
using System.Linq;

namespace DreamDayWeddingPlanningManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Login
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: /Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // For demonstration, using fixed credentials.
                if (model.Email.Trim().ToLower() == "admin@example.com" && model.Password == "AdminPassword")
                {
                    // Set session or authentication as needed.
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Invalid credentials.");
            }
            return View(model);
        }

        // GET: /Admin/Index (Admin Dashboard)
        public IActionResult Index()
        {
            var viewModel = new AdminDashboardViewModel
            {
                Users = _context.Users.ToList(),
                Vendors = _context.Vendors.ToList()
            };

            return View(viewModel);
        }
    }
}
